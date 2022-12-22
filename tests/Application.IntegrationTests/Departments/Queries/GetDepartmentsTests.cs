namespace Application.IntegrationTests.Departments.Queries;

using AutoMapper;
using FluentAssertions;

using nLayer.Application.Departments.Queries.GetDepartments;
using nLayer.Data;
using nLayer.Data.Entities;

public class GetDepartmentsTests : BaseTests
{
    private readonly IMapper mapper;
    
    private ApplicationDbContext context;
    private GetDepartmentsQueryHandler queryHandler;

    public GetDepartmentsTests()
    {
        this.mapper = this.GetMapper();

        this.context = null!;
        this.queryHandler = null!;
    }

    [SetUp]
    public void SetUp()
    {
        this.context = this.GetDatabase();
        this.queryHandler = new GetDepartmentsQueryHandler(
            this.context,
            this.mapper);
    }

    [Test]
    public void GetDepartmentsQueryHandlerIsCreatedCorrectly()
        => this.queryHandler
            .Should()
            .NotBeNull();

    [Test]
    public async Task GetAllReturnsAllItems()
    {
        var department1 = new Department
        {
            Name = "IT",
            CreatedAt = DateTime.Now,
            IsActive = true,
        };

        var department2 = new Department
        {
            Name = "HR",
            CreatedAt = DateTime.Now,
            IsActive = true,
        };

        this.context.Departments.Add(department1);
        this.context.Departments.Add(department2);

        var cts = new CancellationTokenSource();
        await this.context.SaveChangesAsync(cts.Token);

        var query = new GetDepartmentsQuery();

        var result = await this.queryHandler
            .Handle(query, cts.Token);

        result.Count().Should().Be(2);
    }

    [Test]
    public async Task GetAllReturnsEmptyEnumerationIfNoItems()
    {
        var cts = new CancellationTokenSource();
        var query = new GetDepartmentsQuery();

        var result = await this.queryHandler
            .Handle(query, cts.Token);

        result.Count().Should().Be(0);
    }
}
