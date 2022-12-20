namespace nLayer.Services.Models.Employees;

using AutoMapper;

using nLayer.Data.Entities;
using nLayer.Services.Mappings;

using DateTime = System.DateTime;

public class EmployeeDetailsDto : IMapFrom<Employee>
{
    public int Id { get; set; }

    public string Address { get; set; } = string.Empty;

    public int Age { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public string Department { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Employee, EmployeeDetailsDto>()
            .ForMember(
                d => d.Gender,
                opt
                    => opt.MapFrom(s => s.Gender.ToString()))
            .ForMember(
                d => d.Department,
                opt
                    => opt.MapFrom(s => s.Department.Name));
    }
}
