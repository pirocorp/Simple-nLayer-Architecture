namespace Application.IntegrationTests.Employees;

using System.Diagnostics.CodeAnalysis;
using nLayer.Data.Entities;
using nLayer.Data.Enums;

public class BaseEmployeesTests : BaseTests
{
    public IList<Employee> Employees { get; set; }

    public BaseEmployeesTests()
        : base()
    {
        this.InitializeEmployees();
    }

    protected Department CreateDepartment(string departmentName)
        => new ()
        {
            Name = departmentName,
            CreatedAt = this.DateTime,
            IsActive = true
        };

    [MemberNotNull(nameof(Employees))]
    private void InitializeEmployees()
    {
        this.Employees = new List<Employee>
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
