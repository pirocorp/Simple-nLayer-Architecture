namespace nLayer.Application.Departments.Queries.GetDepartments;

using nLayer.Application.Mappings;
using nLayer.Data.Entities;

public class DepartmentListingDto : IMapFrom<Department>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
