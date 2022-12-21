﻿namespace nLayer.Application.Models.Departments;

using nLayer.Application.Mappings;
using nLayer.Data.Entities;

using DateTime = System.DateTime;

public class DepartmentDetailsDto : IMapFrom<Department>
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Name { get; set; } = string.Empty;
}
