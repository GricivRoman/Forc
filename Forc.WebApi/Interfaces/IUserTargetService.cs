using Forc.WebApi.Dto;

namespace Forc.WebApi.Interfaces
{
    public interface IUserTargetService
    {
        Task<UserTargetViewModel> GetTargetAsync(Guid id);
        Task<List<UserTargetViewModel>> GetTargetListAsync(string userName);
        Task<Guid> AddTargetAsync(UserTargetViewModel model);
        Task EditTargetAsync(UserTargetViewModel model);
        Task DeleteTargetAsync(Guid id);
    }
}
