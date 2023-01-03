namespace nLayer.Application.Employees.Commands.CreateEmployee;

using System.ComponentModel.DataAnnotations;

using MediatR;

using static Data.Common.DataConstants.Employee;

public record CreateEmployeeCommand : IRequest<CreateEmployeeDto>
{
    [Required]
    [StringLength(ADDRESS_MAX_LENGTH)]
    public required string Address { get; init; }

    public int Age { get; init; }

    [Required]
    [EmailAddress]
    [StringLength(EMAIL_MAX_LENGTH)]
    public required string Email { get; init; }

    [Required]
    public required string Gender { get; init; }

    [Required]
    [StringLength(NAME_MAX_LENGTH)]
    public required string Name { get; init; }

    public decimal Salary { get; init; }

    public int DepartmentId { get; init; }
}
