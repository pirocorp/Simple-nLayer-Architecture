namespace nLayer.Application.Departments.Queries.GetDepartmentsById;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;
using Microsoft.EntityFrameworkCore;

using nLayer.Data;

public class GetDepartmentsByIdQueryHandler 
    : IRequestHandler<GetDepartmentsByIdQuery, DepartmentFullDetailsDto?>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public GetDepartmentsByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<DepartmentFullDetailsDto?> Handle(
        GetDepartmentsByIdQuery request,
        CancellationToken cancellationToken)
        => await this.context.Departments
            .AsNoTracking()
            .Where(d => d.IsActive)
            .ProjectTo<DepartmentFullDetailsDto>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(
                d => d.Id == request.Id, 
                cancellationToken: cancellationToken);
}
