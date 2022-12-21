namespace nLayer.Application.Employees.Queries.GetEmployeesById;

using MediatR;

public class GetEmployeesByIdQuery : IRequest<GetEmployeesByIdDto>
{
    public int Id { get; set; }
}
