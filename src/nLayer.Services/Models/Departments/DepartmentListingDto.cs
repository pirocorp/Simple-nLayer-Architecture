namespace nLayer.Services.Models.Departments;

using Data.Entities;
using Mappings;

public class DepartmentListingDto : IMapFrom<Department>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
