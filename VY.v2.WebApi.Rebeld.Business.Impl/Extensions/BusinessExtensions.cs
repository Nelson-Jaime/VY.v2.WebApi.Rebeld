using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.v2.WebApi.Rebeld.Business.Contracts.Service;
using VY.v2.WebApi.Rebeld.Business.Impl.Services;
using VY.v2.WebApi.Rebeld.Data.Impl.Extensions;

namespace VY.v2.WebApi.Rebeld.Business.Impl.Extensions
{
    public static class BusinessExtensions
    {
        public static IServiceCollection AddBusinessExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataExtensions(configuration);
            services.AddTransient<IRebeldService, RebeldService>();
            return services;
        }
    }
}
