namespace nLayer.Application.Departments.Commands.RenameDepartment;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using static Data.Common.DataConstants.Department;

public class RenameDepartmentCommand : IRequest<RenameDepartmentDetailsDto>
{
    [Required]
    [StringLength(NAME_MAX_LENGTH)]
    public string Name { get; set; } = string.Empty;

    [BindNever]
    [JsonIgnore]
    public int Id { get; set; }
}
