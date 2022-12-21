namespace nLayer.Application.Employees.Commands.UpdateEmployee;

using AutoMapper;

using MediatR;
using Microsoft.EntityFrameworkCore;

using nLayer.Data;

public class UpdateEmployeeHandler 
    : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeDto?>
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public UpdateEmployeeHandler(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<UpdateEmployeeDto?> Handle(
        UpdateEmployeeCommand request, 
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

        employee.Name = request.Name;
        employee.Age = request.Age;
        employee.Email = request.Email;
        employee.Address = request.Address;
        employee.Salary = request.Salary;
        employee.DepartmentId = request.DepartmentId;

        await this.context.SaveChangesAsync(cancellationToken);

        return this.mapper.Map<UpdateEmployeeDto>(employee);
    }
}
