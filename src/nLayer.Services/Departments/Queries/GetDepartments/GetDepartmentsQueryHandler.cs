namespace nLayer.Application.Departments.Queries.GetDepartments;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;
using Microsoft.EntityFrameworkCore;

using nLayer.Data;

public class GetDepartmentsQueryHandler 
    : IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentListingDto>>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public GetDepartmentsQueryHandler(
        ApplicationDbContext context, 
        IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentListingDto>> Handle(
        GetDepartmentsQuery request, 
        CancellationToken cancellationToken)
        => await this.context.Departments
            .Where(d => d.IsActive)
            .ProjectTo<DepartmentListingDto>(this.mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
}
