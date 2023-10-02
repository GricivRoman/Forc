using Forc.WebApi.Dto;

namespace Forc.WebApi.Interfaces
{
    public interface IPhysicalActivityService
    {
        Task<List<SelectItem<Guid>>> GetPhysicalActivitySelectItems();
    }
}
