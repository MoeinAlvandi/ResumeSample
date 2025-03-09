using Microsoft.Extensions.DependencyInjection;
using ResumeSample.Core.Services.Implementetions;
using ResumeSample.Core.Services.Interfaces;
using ResumeSample.Data.Repositories;
using ResumeSample.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSample.IOC
{
   public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection service)
        {

            service.AddScoped<IUserService, UserService>();//per request
            service.AddScoped<IUserRepository, UserRepository>();


        }
    }
}
