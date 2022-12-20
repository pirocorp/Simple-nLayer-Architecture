namespace nLayer.Api;

using System.Reflection;

using Microsoft.EntityFrameworkCore;

using nLayer.Api.Extensions;
using nLayer.Data;
using nLayer.Services;
using nLayer.Services.DateTime;
using nLayer.Services.Mappings;

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

        services.AddAutoMapper(Assembly.GetAssembly(typeof(IMapFrom<>)));

        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<IDepartmentService, DepartmentService>();
        services.AddTransient<IEmployeeService, EmployeeService>();

        services.AddControllers();

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
