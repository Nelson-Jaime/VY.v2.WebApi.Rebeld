using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.v2.WebApi.Rebeld.Data.Contracts.Entities;
using VY.v2.WebApi.Rebeld.Dtos.Dtos;

namespace VY.v2.WebApi.Rebeld.Business.Impl.Mapping
{
    public class RebeldProfile : Profile
    {
        public RebeldProfile()
        {
            CreateMap<RebeldDto, RebeldEntity>().ReverseMap();
                
        }
    }
}
