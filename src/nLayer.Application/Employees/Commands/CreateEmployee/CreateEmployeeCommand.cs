namespace nLayer.Application.Employees.Commands.CreateEmployee;

using System.ComponentModel.DataAnnotations;

using MediatR;

using static Data.Common.DataConstants.Employee;

public class CreateEmployeeCommand : IRequest<CreateEmployeeDto>
{
    [Required]
    [StringLength(ADDRESS_MAX_LENGTH)]
    public string Address { get; set; } = string.Empty;

    public int Age { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(EMAIL_MAX_LENGTH)]
    public string Email { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    [Required]
    [StringLength(NAME_MAX_LENGTH)]
    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }
}
