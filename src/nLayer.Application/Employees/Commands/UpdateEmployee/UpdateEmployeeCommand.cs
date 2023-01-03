namespace nLayer.Application.Employees.Commands.UpdateEmployee;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using static Data.Common.DataConstants.Employee;

public record UpdateEmployeeCommand : IRequest<UpdateEmployeeDto>
{
    [BindNever]
    [JsonIgnore]
    public int Id { get; init; }

    [Required]
    [StringLength(ADDRESS_MAX_LENGTH)]
    public required string Address { get; init; }

    [Range(AGE_MIN_VALUE, AGE_MAX_VALUE)]
    public int Age { get; init; }

    [Required]
    [EmailAddress]
    [StringLength(EMAIL_MAX_LENGTH)]
    public required string Email { get; init; }

    [Required]
    [StringLength(NAME_MAX_LENGTH)]
    public required string Name { get; init; }

    [Range(SALARY_MIN_VALUE, SALARY_MAX_VALUE)]
    public decimal Salary { get; init; }

    public int DepartmentId { get; init; }
}
