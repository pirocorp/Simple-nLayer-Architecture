namespace nLayer.Application.Employees.Commands.FireEmployee;

using MediatR;

public class FireEmployeeCommand : IRequest<FireEmployeeDto>
{
    public int Id { get; set; }
}
