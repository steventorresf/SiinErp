using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiinErp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiinErp.Configuration
{
    public static class AppContextInjection
    {
        public static IServiceCollection AddDbContextInjection(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddDbContext<SiinErpContext>(options => options.UseSqlServer(configuration.GetConnectionString("SiinErpDbContext")));
                return services;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
