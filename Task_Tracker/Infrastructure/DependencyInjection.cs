using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, Infrastructure.UnitOfWork>();
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
