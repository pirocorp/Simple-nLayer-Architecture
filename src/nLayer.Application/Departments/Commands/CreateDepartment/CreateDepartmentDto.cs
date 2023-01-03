namespace nLayer.Application.Departments.Commands.CreateDepartment;

using System;
using nLayer.Application.Common.Mappings;
using nLayer.Data.Entities;

public class CreateDepartmentDetailsDto : IMapFrom<Department>
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Name { get; set; } = string.Empty;
}
