namespace Services.IntegrationTests.Services;

using AutoMapper;

using FluentAssertions;
using FluentAssertions.Execution;
using nLayer.Data;
using nLayer.Data.Entities;
using nLayer.Data.Enums;
using nLayer.Services;
using nLayer.Services.DateTime;
using nLayer.Services.Exceptions;
using nLayer.Services.Models.Employees;

public class EmployeeServiceTests : BaseServiceTests
{
    private readonly IMapper mapper;
    private readonly IDateTimeService dateTimeService;
    
    private ApplicationDbContext context;
    private IEmployeeService employeeService;
    private List<Employee> employees;

    public EmployeeServiceTests()
    {
        this.dateTimeService = this.GetDateTimeService();
        this.mapper = this.GetMapper();

        this.context = null!;
        this.employeeService = null!;
        this.employees = null!;
    }

    [SetUp]
    public void SetUp()
    {
        this.context = this.GetDatabase();

        this.employeeService = new EmployeeService(
            this.context,
            this.dateTimeService,
            this.mapper);

        this.InitializeEmployees();
    }

    [Test]
    public void EmployeeServiceIsCreatedCorrectly()
        => this.employeeService.Should().NotBeNull();

    [Test]
    public async Task GetByIdWorksCorrectly()
    {
        var cts = new CancellationTokenSource();
        var departmentName = "It";

        await this.context.Employees.AddRangeAsync(this.employees, cts.Token);
        await this.context.Departments.AddAsync(CreateDepartment(departmentName, DateTime.Now), cts.Token);
        await this.context.SaveChangesAsync(cts.Token);

        var expected = this.mapper.Map<EmployeeDetailsDto>(this.employees.First());
        var actual = await this.employeeService
            .GetById(expected.Id);

        actual.Should().NotBeNull();
        actual.Should().BeEquivalentTo(expected);
    }

    [Test]
    public async Task GetByIdShouldReturnNullWithIdIsMissing()
    {
        var actual = await this.employeeService.GetById(-6);

        actual.Should().BeNull();
    }

    [Test]
    public async Task GetAllWorksCorrectly()
    {
        var cts = new CancellationTokenSource();

        await this.context.Employees.AddRangeAsync(this.employees, cts.Token);
        await this.context.Departments.AddAsync(CreateDepartment("IT", DateTime.Now), cts.Token);
        await this.context.SaveChangesAsync(cts.Token);

        var actual = (await this.employeeService.GetAll()).ToList();

        actual.Should().NotBeNull();
        actual.Count.Should().Be(this.employees.Count);
    }

    [Test]
    public async Task CreateEmployeeWorksCorrectly()
    {
        var cts = new CancellationTokenSource();
        var departmentName = "It";

        await this.context.Departments
            .AddAsync(CreateDepartment(departmentName, this.DateTime), cts.Token);

        var dto = new CreateEmployeeDto
        {
            Address = "Valkendal 8, 1853 Strombeek-Bever, Grimbergen",
            Age = 35,
            DepartmentId = 1,
            Email = "postakalka@abv.bg",
            Gender = "Male",
            Name = "Zdravko Zdravkov",
            Salary = 25_000,
        };

        var actual = await this.employeeService.CreateEmployee(dto, cts.Token);

        using (new AssertionScope())
        {
            actual.Should().NotBeNull();
            actual.Name.Should().Be(dto.Name);
            actual.Age.Should().Be(dto.Age);
            actual.Address.Should().Be(dto.Address);
            actual.CreatedAt.Should().Be(this.DateTime);
            actual.Department.Should().Be(departmentName);
            actual.DepartmentId.Should().Be(dto.DepartmentId);
            actual.Salary.Should().Be(dto.Salary);
            actual.Gender.Should().Be(dto.Gender);
            actual.Email.Should().Be(dto.Email);
        }
    }

    [Test]
    public async Task CreateEmployeeThrowsWithInvalidGender()
    {
        var dto = new CreateEmployeeDto
        {
            Address = "Valkendal 8, 1853 Strombeek-Bever, Grimbergen",
            Age = 35,
            DepartmentId = 1,
            Email = "postakalka@abv.bg",
            Gender = "INVALID",
            Name = "Zdravko Zdravkov",
            Salary = 25_000,
        };

        await FluentActions
            .Invoking(async() => await this.employeeService.CreateEmployee(dto, CancellationToken.None))
            .Should()
            .ThrowAsync<InvalidGenderException>();
    }

    [Test]
    public async Task CreateEmployeeShouldThrowWithCanceledToken()
    {
        var cts = new CancellationTokenSource();
        cts.Cancel();

        var dto = new CreateEmployeeDto
        {
            Address = "Valkendal 8, 1853 Strombeek-Bever, Grimbergen",
            Age = 35,
            DepartmentId = 1,
            Email = "postakalka@abv.bg",
            Gender = "Male",
            Name = "Zdravko Zdravkov",
            Salary = 25_000,
        };

        await FluentActions
            .Invoking(async() => await this.employeeService.CreateEmployee(dto, cts.Token))
            .Should()
            .ThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task FireEmployeeWorksCorrectly()
    {
        var cts = new CancellationTokenSource();
        var departmentName = "It";

        await this.context.Employees.AddRangeAsync(this.employees, cts.Token);
        await this.context.Departments.AddAsync(CreateDepartment(departmentName, DateTime.Now), cts.Token);
        await this.context.SaveChangesAsync(cts.Token);

        var expected = this.employees.First();

        expected.IsActive.Should().BeTrue();

        await this.employeeService.FireEmployee(expected.Id, cts.Token);

        expected.IsActive.Should().BeFalse();
    }

    [Test]
    public async Task FireEmployeeShouldThrowsWithCanceledToken()
    {
        var cts = new CancellationTokenSource();
        var departmentName = "It";

        await this.context.Employees.AddRangeAsync(this.employees, cts.Token);
        await this.context.Departments.AddAsync(CreateDepartment(departmentName, DateTime.Now), cts.Token);
        await this.context.SaveChangesAsync(cts.Token);

        var expected = this.employees.First();
        cts.Cancel();

        await FluentActions.Invoking(async () => await this.employeeService.FireEmployee(expected.Id, cts.Token))
            .Should()
            .ThrowAsync<TaskCanceledException>();
    }

    [Test]
    public async Task FireEmployeeReturnsNullWithInvalidId()
    {
        var expected = await this.employeeService.FireEmployee(-6, CancellationToken.None);

        expected.Should().BeNull();
    }

    [Test]
    public async Task UpdateEmployeeWorksCorrectly()
    {
        var cts = new CancellationTokenSource();
        var departmentName = "It";

        await this.context.Employees.AddRangeAsync(this.employees, cts.Token);
        await this.context.Departments.AddAsync(CreateDepartment(departmentName, DateTime.Now), cts.Token);
        await this.context.SaveChangesAsync(cts.Token);

        var dto = new UpdateEmployeeDto
        {
            Address = "Saedinenie 16, 9701 Shumen, Shumen",
            Age = 35,
            DepartmentId = 1,
            Email = "asd@asd.com",
            Name = "Piroman Piromanov",
            Salary = 125_000
        };

        var response = await this.employeeService.Update(1, dto, cts.Token);

        using (new AssertionScope())
        {
            response.Should().NotBeNull();
            response?.Address.Should().Be(dto.Address);
            response?.Age.Should().Be(dto.Age);
            response?.DepartmentId.Should().Be(dto.DepartmentId);
            response?.Department.Should().Be(departmentName);
            response?.Email.Should().Be(dto.Email);
            response?.Name.Should().Be(dto.Name);
            response?.Salary.Should().Be(dto.Salary);
        }
    }

    [Test]
    public async Task UpdateEmployeeReturnsNullWithInvalidId()
    {
        var cts = new CancellationTokenSource();
        var dto = new UpdateEmployeeDto();

        var response = await this.employeeService.Update(-51, dto, cts.Token);

        response.Should().BeNull();
    }

    private void InitializeEmployees()
    {
        this.employees = new List<Employee>
        {
            new Employee
            {
                Name = "Zdravko Zdravkov",
                Age = 35,
                CreatedAt = DateTime.Now,
                Email = "postakalka@abv.bg",
                Address = "Valkendal 8, 1853 Strombeek-Bever, Grimbergen",
                Gender = Gender.Male,
                Salary = 25_000,
                DepartmentId = 1,

                IsActive = true,
            },
            new Employee
            {
                Name = "Asen Zlatarov",
                Age = 35,
                CreatedAt = DateTime.Now,
                Email = "postakalka@abv.bg",
                Address = "Valkendal 8, 1853 Strombeek-Bever, Grimbergen",
                Gender = Gender.Male,
                Salary = 25_000,
                DepartmentId = 1,

                IsActive = true,
            },
        };
    }
}
