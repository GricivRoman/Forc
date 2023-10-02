using AutoMapper;
using Forc.WebApi.Data;
using Forc.WebApi.Dto;
using Forc.WebApi.Infrastructure.Entities;
using Forc.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forc.WebApi.Services
{
    public class PhysicalActivityService : IPhysicalActivityService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PhysicalActivityService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SelectItem<Guid>>> GetPhysicalActivitySelectItems()
        {
            var physicalAcctivities = await _context.Set<PhysicalActivity>().ToListAsync();

            return _mapper.Map<List<SelectItem<Guid>>>(physicalAcctivities);
        }
    }
}
