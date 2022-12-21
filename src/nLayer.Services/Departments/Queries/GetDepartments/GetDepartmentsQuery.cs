namespace nLayer.Application.Departments.Queries.GetDepartments;

using MediatR;

public record GetDepartmentsQuery : IRequest<IEnumerable<DepartmentListingDto>>
{ }
