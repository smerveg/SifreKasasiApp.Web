using Microsoft.Extensions.DependencyInjection;
using SifreKasasiApp.Business.Abstract;
using SifreKasasiApp.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Business.Extensions
{
    public static class BusinessLayerExtension
    {
        public static IServiceCollection LoadBusinessExtension(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserAccountService, UserAccountService>();

            var assembly = Assembly.GetExecutingAssembly();
            service.AddAutoMapper(assembly);
            return service;
        }
    }
}
