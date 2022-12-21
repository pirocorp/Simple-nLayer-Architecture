namespace nLayer.Application.Employees.Commands.FireEmployee;

using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class FireEmployeeHandler : IRequestHandler<FireEmployeeCommand, FireEmployeeDto?>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public FireEmployeeHandler(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<FireEmployeeDto?> Handle(
        FireEmployeeCommand request, 
        CancellationToken cancellationToken)
    {
        var employee = await this.context.Employees
            .Where(e => e.IsActive)
            .Include(e => e.Department)
            .FirstOrDefaultAsync(
                e => e.Id == request.Id,
                cancellationToken);

        if (employee is null)
        {
            return null;
        }
        
        employee.IsActive = false;
        await this.context.SaveChangesAsync(cancellationToken);

        return this.mapper.Map<FireEmployeeDto>(employee);
    }
}
