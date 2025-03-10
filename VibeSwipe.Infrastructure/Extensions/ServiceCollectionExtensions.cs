using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VibeSwipe.Domain.Contracts.Repos;
using VibeSwipe.Infrastructure.Persistance;
using VibeSwipe.Infrastructure.Repositories;

namespace VibeSwipe.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
#if DEBUG
                options.EnableSensitiveDataLogging();
#endif
            });

            services.AddScoped<IUserRepo, UserRepo>();

            return services;
        }
    }
}
