using AutoMapper;
using Forc.WebApi.Data;
using Forc.WebApi.Dto;
using Forc.WebApi.Infrastructure.Entities;
using Forc.WebApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forc.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Set<User>().Where(x => x.Id == id).SingleOrDefaultAsync();
            _context.Set<User>().Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUserAsync(Guid id)
        {
            var user = await _context.Set<User>()
                .Where(x => x.Id == id)
                .Include(x => x.PhysicalActivity)
                .SingleOrDefaultAsync();

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task UpdateUserAsync(UserViewModel model)
        {
            var user = await _context.Set<User>().Where(x => x.Id == model.Id).SingleOrDefaultAsync();

            user.Name = model.Name;
            user.Gender = model.Gender;
            user.BirthDate = model.BirthDate;
            user.Sex = model.Sex?.Id;
            user.PhysicalActivityId = model.PhysicalActivity?.Id;
            user.Height = model.Height;

            await _context.SaveChangesAsync();
        }
    }
}
