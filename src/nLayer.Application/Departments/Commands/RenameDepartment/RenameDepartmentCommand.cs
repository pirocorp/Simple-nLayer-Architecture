namespace nLayer.Application.Departments.Commands.RenameDepartment;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using static Data.Common.DataConstants.Department;

public record RenameDepartmentCommand : IRequest<RenameDepartmentDetailsDto>
{
    [Required]
    [StringLength(NAME_MAX_LENGTH)]
    public required string Name { get; init; }

    [BindNever]
    [JsonIgnore]
    public int Id { get; init; }
}
