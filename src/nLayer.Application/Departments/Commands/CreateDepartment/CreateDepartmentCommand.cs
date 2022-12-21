namespace nLayer.Application.Departments.Commands.CreateDepartment;

using MediatR;

using System.ComponentModel.DataAnnotations;

public class CreateDepartmentCommand : IRequest<CreateDepartmentDetailsDto>
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
}
