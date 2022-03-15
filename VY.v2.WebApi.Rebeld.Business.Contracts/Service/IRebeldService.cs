using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.v2.WebApi.Rebeld.Dtos.Dtos;

namespace VY.v2.WebApi.Rebeld.Business.Contracts.Service
{
    public interface IRebeldService
    {
        Task<RebeldDto> AddRebeldAsync(RebeldDto rebeld);
        Task<RebeldDto> GetRebeldByIdAsync(Guid id);
        Task<IEnumerable<RebeldDto>> GetAllRebeldsAsync();
        Task<bool> UpdateRebeldAsync(Guid id, RebeldDto rebeldDto);
        Task<bool> DeleteRebeldAsync(Guid id);
    }
}
