namespace nLayer.Application.Departments.Commands.DeleteDepartment;

using nLayer.Application.Common.Mappings;
using nLayer.Data.Entities;

public class DeleteDepartmentDetailsDto : IMapFrom<Department>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
