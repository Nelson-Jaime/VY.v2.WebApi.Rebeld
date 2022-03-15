using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VY.v2.WebApi.Rebeld.Data.Contracts.Entities;
using System.Threading.Tasks;

namespace VY.v2.WebApi.Rebeld.Data.Contracts.Repository
{
    public interface IRebeldRepository
    {
       Task<IEnumerable<RebeldEntity>> GetAllAsync();
        Task<RebeldEntity> GetAsync(Guid id);
        Task<RebeldEntity> AddAsync(RebeldEntity rebeld);
        Task<bool> UpdateAsync(RebeldEntity rebeld);
        Task<bool> DeleteAsync(Guid id);
    }
}
