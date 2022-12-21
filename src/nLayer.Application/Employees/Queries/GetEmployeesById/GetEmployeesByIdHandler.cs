namespace nLayer.Application.Employees.Queries.GetEmployeesById;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;
using Microsoft.EntityFrameworkCore;

using nLayer.Data;

public class GetEmployeesByIdHandler 
    : IRequestHandler<GetEmployeesByIdQuery, GetEmployeesByIdDto?>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public GetEmployeesByIdHandler(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<GetEmployeesByIdDto?> Handle(
        GetEmployeesByIdQuery request,
        CancellationToken cancellationToken)
        => await this.context.Employees
            .Where(e => e.IsActive)
            .AsNoTracking()
            .ProjectTo<GetEmployeesByIdDto>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(
                e => e.Id == request.Id, 
                cancellationToken);
}
