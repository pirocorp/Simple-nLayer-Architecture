namespace nLayer.Api;

using Application;

using Microsoft.EntityFrameworkCore;

using nLayer.Api.Extensions;
using nLayer.Api.Filters;
using nLayer.Data;

public class Program
{
    private static string? sqlServerConnectionString;

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureConfiguration(builder.Configuration);
        ConfigureServices(builder.Services);

        var app = builder.Build();

        ConfigureMiddleware(app);
        ConfigureEndpoints(app);

        app.Run();
    }

    private static void ConfigureConfiguration(IConfiguration configuration)
    {
        sqlServerConnectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(sqlServerConnectionString));

        services.AddApplicationServices();

        services.AddControllers(
            options => options.Filters.Add<ApiExceptionFilterAttribute>());

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void ConfigureMiddleware(WebApplication app)
    {
        app.UseDatabaseMigrations<ApplicationDbContext>();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
    }

    private static void ConfigureEndpoints(WebApplication app)
    {
        app.MapControllers();
    }
}
