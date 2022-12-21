namespace nLayer.Application.Employees.Commands.UpdateEmployee;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using static Data.Common.DataConstants.Employee;

public class UpdateEmployeeCommand : IRequest<UpdateEmployeeDto>
{
    [BindNever]
    [JsonIgnore]
    public int Id { get; set; }

    [Required]
    [StringLength(NAME_MAX_LENGTH)]
    public string Name { get; set; } = string.Empty;

    [Range(AGE_MIN_VALUE, AGE_MAX_VALUE)]
    public int Age { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(EMAIL_MAX_LENGTH)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(ADDRESS_MAX_LENGTH)]
    public string Address { get; set; } = string.Empty;

    [Range(SALARY_MIN_VALUE, SALARY_MAX_VALUE)]
    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }
}
