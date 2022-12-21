namespace nLayer.Application.Departments.Commands.DeleteDepartment;

using AutoMapper;

using MediatR;
using Microsoft.EntityFrameworkCore;

using nLayer.Data;

public class DeleteDepartmentHandler 
    : IRequestHandler<DeleteDepartmentCommand, DeleteDepartmentDetailsDto?>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public DeleteDepartmentHandler(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<DeleteDepartmentDetailsDto?> Handle(
        DeleteDepartmentCommand request, 
        CancellationToken cancellationToken)
    {
        var department = await this.context.Departments
            .Where(d => d.IsActive)
            .FirstOrDefaultAsync(
                d => d.Id == request.Id,
                cancellationToken);

        if (department is null)
        {
            return null;
        }

        department.IsActive = false;
        await this.context.SaveChangesAsync(cancellationToken);

        return this.mapper.Map<DeleteDepartmentDetailsDto>(department);
    }
}
