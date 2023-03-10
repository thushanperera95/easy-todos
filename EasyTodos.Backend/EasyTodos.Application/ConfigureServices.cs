using EasyTodos.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace EasyTodos.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}