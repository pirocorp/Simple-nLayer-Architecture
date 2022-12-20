namespace nLayer.Services.Models.Departments;

using nLayer.Data.Entities;
using nLayer.Services.Mappings;

using DateTime = System.DateTime;

public class DepartmentDetailsDto : IMapFrom<Department>
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Name { get; set; } = string.Empty;
}
