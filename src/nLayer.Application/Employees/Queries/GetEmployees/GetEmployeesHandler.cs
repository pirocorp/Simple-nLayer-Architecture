namespace nLayer.Application.Employees.Queries.GetEmployees;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;
using Microsoft.EntityFrameworkCore;

using nLayer.Data;

public class GetEmployeesHandler 
    : IRequestHandler<GetEmployeesQuery, IEnumerable<GetEmployeesListingDto>>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public GetEmployeesHandler(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<GetEmployeesListingDto>> Handle(
        GetEmployeesQuery request,
        CancellationToken cancellationToken)
        => await this.context.Employees
            .Where(e => e.IsActive)
            .ProjectTo<GetEmployeesListingDto>(this.mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
}
