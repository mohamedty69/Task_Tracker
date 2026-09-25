using Application.Interfaces;
using Application.Interfaces.IServices;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, Infrastructure.UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
