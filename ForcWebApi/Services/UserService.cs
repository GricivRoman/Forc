using AutoMapper;
using Forc.Infrastructure.Data;
using Forc.Infrastructure.Models;
using Forc.WebApi.Dto;
using Forc.WebApi.Dto.FileStorage;
using Forc.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forc.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;
        private const string _fileStoragePath = "/user";

        public UserService(DataContext context, IMapper mapper, IFileStorageService fileStorageService)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
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

        public async Task<Guid> UpdateUserAsync(UserViewModel model)
        {
            var user = await _context.Set<User>().Where(x => x.Id == model.Id).SingleOrDefaultAsync();

            user.Name = model.Name;
            user.Gender = model.Gender;
            user.BirthDate = model.BirthDate;
            user.Sex = model.Sex?.Id;
            user.PhysicalActivityId = model.PhysicalActivity?.Id;
            user.Height = model.Height;
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task UploadPhotoAsync(FileToUploadViewModel fileModel)
        {
            await _fileStorageService.UploadFileAsync(_fileStoragePath, fileModel);
        }

        public async Task<FileViewModel> GetPhotoAsync(Guid id)
        {
            return await _fileStorageService.GetFileAsync(_fileStoragePath, id);
        }
    }
}
