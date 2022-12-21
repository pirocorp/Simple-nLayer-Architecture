namespace nLayer.Application.Models.Employees;

using AutoMapper;

using nLayer.Application.Mappings;
using nLayer.Data.Entities;

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
