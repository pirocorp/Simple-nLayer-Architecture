namespace Services.IntegrationTests.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;

using nLayer.Data;
using nLayer.Data.Entities;
using nLayer.Services.DateTime;
using nLayer.Services.Mappings;

public abstract class BaseServiceTests
{
    protected readonly DateTime DateTime;

    protected BaseServiceTests()
    {
        this.DateTime = DateTime.UtcNow;
    }

    protected IMapper GetMapper()
    {
        var configuration = new MapperConfiguration(
            config
                => config.AddProfile<MappingProfile>());

        return configuration.CreateMapper();
    }

    protected IDateTimeService GetDateTimeService()
    {
        var moq = new Mock<IDateTimeService>();

        moq.Setup(x => x.Now)
            .Returns(this.DateTime);

        return moq.Object;
    }

    protected ApplicationDbContext GetDatabase()
    {
        var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(dbOptions);
    }

    protected static Department CreateDepartment(string name, DateTime createdAt)
        => new ()
        {
            CreatedAt = createdAt,
            IsActive = true,
            Name = name,
            Employees = new HashSet<Employee>()
        };
}
