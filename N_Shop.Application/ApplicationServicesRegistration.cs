using Microsoft.Extensions.DependencyInjection;
using N_Shop.Application.Contracts.Accessor;
using N_Shop.Application.Contracts.Infrastructure.GUID;
using N_Shop.Application.Contracts.Infrastructure.Math;
using N_Shop.Application.Helpers.Accessor;
using N_Shop.Application.Helpers.GUID;
using N_Shop.Application.Helpers.Math;
using System.Reflection;

namespace N_Shop.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApllicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient<ICodeGenerate, CodeGenerate>();

            services.AddTransient<IComputationsMath, ComputationsMath>();

            services.AddScoped<IUserAccessor, UserAccessor>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
