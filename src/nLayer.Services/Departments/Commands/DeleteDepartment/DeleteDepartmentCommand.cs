namespace nLayer.Application.Departments.Commands.DeleteDepartment;

using MediatR;

public class DeleteDepartmentCommand : IRequest<DeleteDepartmentDetailsDto>
{
    public int Id { get; set; }
}
