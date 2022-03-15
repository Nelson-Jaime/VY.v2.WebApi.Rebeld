using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.v2.WebApi.Rebeld.Data.Contracts.Repository;
using VY.v2.WebApi.Rebeld.Data.Impl.Repository;

namespace VY.v2.WebApi.Rebeld.Data.Impl.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRebeldRepository>(x => new RebeldRepository(configuration["File"]));
            return services;
        }
    }
}
