using Microsoft.Extensions.DependencyInjection;

namespace VibeSwipe.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(MediatRRoot).Assembly);
            });

            return services; 
        }
    }
}
