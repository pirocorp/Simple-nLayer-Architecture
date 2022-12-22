﻿namespace nLayer.Application.Employees.Commands.CreateEmployee;

using AutoMapper;

using nLayer.Application.Mappings;
using nLayer.Data.Entities;

public class CreateEmployeeDto : IMapFrom<Employee>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Employee, CreateEmployeeDto>()
            .ForMember(
                d => d.Department,
                opt
                    => opt.MapFrom(s => s.Department.Name));
    }
}