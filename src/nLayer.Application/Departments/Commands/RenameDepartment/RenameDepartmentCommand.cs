namespace nLayer.Application.Departments.Commands.RenameDepartment;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class RenameDepartmentCommand : IRequest<RenameDepartmentDetailsDto>
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [BindNever]
    [JsonIgnore]
    public int Id { get; set; }
}
