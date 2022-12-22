namespace Application.IntegrationTests.Departments.Queries;

using AutoMapper;
using FluentAssertions;

using nLayer.Application.Departments.Queries.GetDepartmentsById;
using nLayer.Data;
using nLayer.Data.Entities;

public class GetDepartmentsByIdTests : BaseTests
{
    private readonly IMapper mapper;
    
    private ApplicationDbContext context;
    private GetDepartmentsByIdQueryHandler queryHandler;

    public GetDepartmentsByIdTests()
    {
        this.mapper = this.GetMapper();

        this.context = null!;
        this.queryHandler = null!;
    }

    [SetUp]
    public void SetUp()
    {
        this.context = this.GetDatabase();
        this.queryHandler = new GetDepartmentsByIdQueryHandler(
            this.context,
            this.mapper);
    }

    [Test]
    public void GetDepartmentsByIdQueryHandlerIsCreatedCorrectly()
        => this.queryHandler
            .Should()
            .NotBeNull();

    [Test]
    public async Task GetByIdReturnsCorrectItem()
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

        var expected = this.mapper
            .Map<DepartmentFullDetailsDto>(department1);

        var query = new GetDepartmentsByIdQuery(department1.Id);

        var actual = await this.queryHandler
            .Handle(query, cts.Token);

        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public async Task GetByIdReturnsNullIfNoItemIsFound()
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

        var query = new GetDepartmentsByIdQuery(-6);

        var actual = await this.queryHandler
            .Handle(query, cts.Token);

        actual.Should().BeNull();
    }
}
