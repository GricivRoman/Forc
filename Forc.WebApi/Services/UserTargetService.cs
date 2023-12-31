﻿using AutoMapper;
using Forc.Infrastructure.Data;
using Forc.Infrastructure.Models;
using Forc.WebApi.Dto;
using Forc.WebApi.Extensions;
using Forc.WebApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forc.WebApi.Services
{
    public class UserTargetService : IUserTargetService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IDailyRateCalculationService _dailyRateCalculationService;
        private readonly UserManager<User> _userManager;

        public UserTargetService(
            DataContext context,
            IMapper mapper,
            IDailyRateCalculationService dailyRateCalculationService,
            UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _dailyRateCalculationService = dailyRateCalculationService;
            _userManager = userManager;
        }

        public async Task<UserTargetViewModel> GetTargetAsync(Guid id)
        {
            var userTarget = await _context.Set<UserTarget>().Where(x => x.Id == id).SingleOrDefaultAsync();

            return _mapper.Map<UserTargetViewModel>(userTarget);
        }

        public async Task<List<UserTargetViewModel>> GetTargetListAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userTargets = await _context.Set<UserTarget>()
                .Where(x => x.UserId == user.Id)
                .Include(x => x.DailyRate)                
                .OrderByDescending(x => x.Relevance == true)
                .ThenByDescending(x => x.DateStart)
                .ToListAsync();

            return _mapper.Map<List<UserTargetViewModel>>(userTargets);
        }

        public async Task<Guid> AddTargetAsync(UserTargetViewModel model)
        {
            var user = await _context.Set<User>()
                .Where(x => x.Id == model.UserId)
                .Include(x => x.Targets)
                .Include(x => x.PhysicalActivity)
                .SingleOrDefaultAsync();

            var target = _mapper.Map<UserTarget>(model);
            
            target.User = user;
            target.DailyRate = _dailyRateCalculationService.CalculateDailyRate(target);
            target.Relevance = true;

            if (user.Targets != null)
            {
                user.Targets = user.Targets.Map(x => x.Relevance = false);
                user.Targets.Add(target);
            }
            else
            {
                var targets = new List<UserTarget>() { target };
                user.Targets = targets;
            }

            await _context.SaveChangesAsync();

            return user.Targets.Last().Id;
        }

        public async Task EditTargetAsync(UserTargetViewModel model)
        {
            var target = await _context.Set<UserTarget>()
                .Where(x => x.Id == model.Id)
                .Include(x => x.DailyRate)
                .Include(x => x.User)
                .ThenInclude(x => x.PhysicalActivity)
                .SingleOrDefaultAsync();

            target.DateStart = model.DateStart;
            target.DateFinish= model.DateFinish;
            target.CurrentBodyWeight = model.CurrentBodyWeight;
            target.TargetBodyWeight = model.TargetBodyWeight;

            var dailyRate = _dailyRateCalculationService.CalculateDailyRate(target);

            target.DailyRate.CaloriesRate = dailyRate.CaloriesRate;
            target.DailyRate.FatRate = dailyRate.FatRate;
            target.DailyRate.ProteinRate = dailyRate.ProteinRate;
            target.DailyRate.CarbohydrateRate = dailyRate.CarbohydrateRate;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTargetAsync(Guid id)
        {
            var target = await _context.Set<UserTarget>().Where(x => x.Id == id).SingleOrDefaultAsync();
            _context.Set<UserTarget>().Remove(target);

            if (target.Relevance)
            {
                var previousTarget = await _context.Set<UserTarget>()
                    .OrderBy(x => x.DateStart)
                    .LastOrDefaultAsync();

                if(previousTarget != null)
                {
                    previousTarget.Relevance = true;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
