namespace nLayer.Application.Departments.Commands.RenameDepartment;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

using nLayer.Data;

public class RenameDepartmentHandler : IRequestHandler<RenameDepartmentCommand, RenameDepartmentDetailsDto?>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public RenameDepartmentHandler(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<RenameDepartmentDetailsDto?> Handle(
        RenameDepartmentCommand request, 
        CancellationToken cancellationToken)
    {
        var department = await this.context.Departments
            .Where(d => d.IsActive)
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (department is null)
        {
            return null;
        }

        department.Name = request.Name;
        await this.context.SaveChangesAsync(cancellationToken);

        return this.mapper.Map<RenameDepartmentDetailsDto>(department);
    }
}
