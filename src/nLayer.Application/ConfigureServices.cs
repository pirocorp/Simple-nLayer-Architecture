namespace nLayer.Application;

using System.Reflection;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

using nLayer.Application.Behaviors;
using nLayer.Application.DateTime;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddTransient<IDateTimeService, DateTimeService>();

        // MediatR pipeline 
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
