namespace nLayer.Application.Departments.Commands.CreateDepartment;

using MediatR;

using System.ComponentModel.DataAnnotations;

using static Data.Common.DataConstants.Department;

public record CreateDepartmentCommand : IRequest<CreateDepartmentDetailsDto>
{
    [Required]
    [StringLength(NAME_MAX_LENGTH)]
    public required string Name { get; init; }
}
