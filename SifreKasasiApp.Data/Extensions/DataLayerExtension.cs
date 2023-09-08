using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SifreKasasiApp.Data.Context;
using SifreKasasiApp.Data.Repositories.Abstract;
using SifreKasasiApp.Data.Repositories.Concrete;
using SifreKasasiApp.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Data.Extensions
{
    public static class DataLayerExtension
    {
        public static IServiceCollection LoadDataExtension(this IServiceCollection service,
            IConfiguration config)
        {
            service.AddDbContext<SifreKasasiAppContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            return service;
        }
    }
}
