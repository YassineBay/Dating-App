using AutoMapper;
using Dating_App.Data;
using Dating_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAuthRepository, AuthRepository>(); //for each httpRequest it creates a new Instance of Repository is created
            services.AddTransient<Seed>();
            services.AddScoped<IDatingRepository<User>, DatingRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
