using AutoMapper;
using Forc.WebApi.Data;
using Forc.WebApi.Dto;
using Forc.WebApi.Infrastructure.Entities;
using Forc.WebApi.Interfaces;
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

        public async Task DeleteUser(Guid id)
        {
            var user = await GetUserByID(id);
            _context.Set<User>().Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUser(Guid id)
        {
            var user = await GetUserByID(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task UpdateUser(UserViewModel model)
        {
            var user = await GetUserByID(model.Id);

            user.Name = model.Name;
            user.Gender = model.Gender;
            user.BirthDate = model.BirthDate;
            user.Sex = model.Sex;
            user.PhysicalActivityId = model.PhysicalActivityId;
            user.Height = model.Height;

            await _context.SaveChangesAsync();
        }

        private async Task<User> GetUserByID(Guid id)
        {
            var user = await _context.Set<User>().Where(x => x.Id == id).SingleOrDefaultAsync();

            if (user == null)
            {
                throw new InvalidOperationException("User doesn't exist");
            }

            return user;
        }
    }
}
