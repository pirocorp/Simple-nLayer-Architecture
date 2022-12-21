namespace nLayer.Application.Employees.Queries.GetEmployees;

using MediatR;

public record GetEmployeesQuery : IRequest<IEnumerable<GetEmployeesListingDto>>
{ }
