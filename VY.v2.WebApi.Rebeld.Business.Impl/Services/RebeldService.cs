using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.v2.WebApi.Rebeld.Business.Contracts.Service;
using VY.v2.WebApi.Rebeld.Data.Contracts.Repository;
using VY.v2.WebApi.Rebeld.Dtos.Dtos;
using VY.v2.WebApi.Rebeld.Data.Contracts;
using VY.v2.WebApi.Rebeld.Data.Contracts.Entities;

namespace VY.v2.WebApi.Rebeld.Business.Impl.Services
{
    public class RebeldService : IRebeldService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<RebeldService> _logger;
        private readonly IRebeldRepository _rebeldRepository;

        public RebeldService(IMapper mapper, ILogger<RebeldService> logger, IRebeldRepository rebeldRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _rebeldRepository = rebeldRepository;
        }

        public async Task<RebeldDto> GetRebeldByIdAsync(Guid id)
        {
            RebeldDto result = new RebeldDto();

            try
            {
                var rebeld = await _rebeldRepository.GetAsync(id);
                result = _mapper.Map<RebeldEntity, RebeldDto>(rebeld);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public async Task<IEnumerable<RebeldDto>> GetAllRebeldsAsync()
        {
            IEnumerable<RebeldDto> result = new List<RebeldDto>();

            try
            {
                var rebelds = await _rebeldRepository.GetAllAsync();
                result = _mapper.Map<IEnumerable<RebeldEntity>, IEnumerable<RebeldDto>>(rebelds);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public async Task<RebeldDto> AddRebeldAsync(RebeldDto rebeldDto)
        {
            RebeldDto result = new RebeldDto();

            try
            {
                var rebeld = _mapper.Map<RebeldDto, RebeldEntity>(rebeldDto);
                await _rebeldRepository.AddAsync(rebeld);
                result = _mapper.Map<RebeldEntity, RebeldDto>(rebeld);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public async Task<bool> UpdateRebeldAsync(Guid id, RebeldDto rebeldDto)
        {
            bool result = new bool();

            try
            {
                var rebeld = _mapper.Map<RebeldDto, RebeldEntity>(rebeldDto);
                rebeld.Id = id;
                result = await _rebeldRepository.UpdateAsync(rebeld);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        public async Task<bool> DeleteRebeldAsync(Guid id)
        {
            bool result = new bool();

            try
            {
                result = await _rebeldRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }
    }
}
