namespace nLayer.Services.Models.Employees;

using AutoMapper;

using nLayer.Data.Entities;
using nLayer.Services.Mappings;

public class EmployeeDto : IMapFrom<Employee>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string Department { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Employee, EmployeeDto>()
            .ForMember(
                d => d.Department,
                opt
                    => opt.MapFrom(s => s.Department.Name));
    }
}
