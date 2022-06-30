using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VY.v2.WebApi.Rebeld.Business.Contracts.Service;
using VY.v2.WebApi.Rebeld.Dtos.Dtos;

//ESTO ES SOLO PARA UNA PRUEBA

namespace VY.v2.WebApi.Rebeld.App.Controllers.V1
{

    [Route("api/[controller]")]
    [ApiController]
    public class RebeldController : ControllerBase
    {
        private readonly IRebeldService _rebeldService;

        public RebeldController(IRebeldService rebeldService)
        {
            _rebeldService = rebeldService;
        }



        /// <summary>
        /// Get all Rebelds
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(IEnumerable<RebeldDto>))]
        [ProducesResponseType(500, Type = typeof(void))]
        [ProducesResponseType(204, Type = typeof(void))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _rebeldService.GetAllRebeldsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get Rebeld by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(RebeldDto))]
        [ProducesResponseType(500, Type = typeof(void))]
        [ProducesResponseType(404, Type = typeof(void))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _rebeldService.GetRebeldByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Add a rebeld
        /// </summary>
        /// <param name="rebeld"></param>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(RebeldDto))]
        [ProducesResponseType(500, Type = typeof(void))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RebeldDto rebeldDto)
        {
            var result = await _rebeldService.AddRebeldAsync(rebeldDto);
            return Ok(result);
        }

        /// <summary>
        /// Updates a Rebeld
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rebeld"></param>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(void))]
        [ProducesResponseType(404, Type = typeof(void))]
        [ProducesResponseType(500, Type = typeof(void))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] RebeldDto rebelDto)
        {
            var result = await _rebeldService.UpdateRebeldAsync(id, rebelDto);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a Rebeld
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(void))]
        [ProducesResponseType(500, Type = typeof(void))]
        [ProducesResponseType(404, Type = typeof(void))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _rebeldService.DeleteRebeldAsync(id);

            return Ok(result);
        }
    }
}
