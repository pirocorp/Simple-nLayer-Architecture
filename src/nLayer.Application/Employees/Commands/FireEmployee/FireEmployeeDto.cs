namespace nLayer.Application.Employees.Commands.FireEmployee;

using AutoMapper;
using nLayer.Application.Common.Mappings;
using nLayer.Data.Entities;

public class FireEmployeeDto : IMapFrom<Employee>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Employee, FireEmployeeDto>()
            .ForMember(
                d => d.Department,
                opt
                    => opt.MapFrom(s => s.Department.Name));
    }
}
