namespace nLayer.Application.Departments.Queries.GetDepartmentsById;

using System;

using AutoMapper;

using nLayer.Application.Mappings;
using nLayer.Data.Entities;

public class DepartmentFullDetailsDto : IMapFrom<Department>
{
    public DepartmentFullDetailsDto()
    {
        Employees = new List<EmployeeListingDto>();
    }

    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Name { get; set; } = string.Empty;

    public IEnumerable<EmployeeListingDto> Employees { get; set; }

    public void Mapping(Profile profile)
        => profile
            .CreateMap<Department, DepartmentFullDetailsDto>()
            .ForMember(
                d => d.Employees,
                opt
                    => opt.MapFrom(s => s.Employees));
}
