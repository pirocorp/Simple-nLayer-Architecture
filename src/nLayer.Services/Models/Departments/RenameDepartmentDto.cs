﻿namespace nLayer.Services.Models.Departments;

using System.ComponentModel.DataAnnotations;

public class RenameDepartmentDto
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
}
