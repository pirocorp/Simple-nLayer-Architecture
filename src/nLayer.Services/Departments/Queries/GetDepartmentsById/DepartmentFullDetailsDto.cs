namespace nLayer.Application.Departments.Queries.GetDepartmentsById;

using AutoMapper;

using nLayer.Application.Mappings;
using nLayer.Application.Models.Departments;
using nLayer.Data.Entities;

public class DepartmentFullDetailsDto : DepartmentDetailsDto, IMapFrom<Department>
{
    public DepartmentFullDetailsDto()
    {
        Employees = new List<EmployeeListingDto>();
    }

    public IEnumerable<EmployeeListingDto> Employees { get; set; }

    public void Mapping(Profile profile)
        => profile
            .CreateMap<Department, DepartmentFullDetailsDto>()
            .ForMember(
                d => d.Employees,
                opt
                    => opt.MapFrom(s => s.Employees));
}
