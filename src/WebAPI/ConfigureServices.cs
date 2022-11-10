using FluentValidation.AspNetCore;
using WebAPI.Filters;

namespace WebAPI
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddControllers(options =>
                                    options.Filters.Add<ApiExceptionFilterAttribute>())
                                    .AddFluentValidation(x => x.AutomaticValidationEnabled = true);

            return services;
        }
    }
}
