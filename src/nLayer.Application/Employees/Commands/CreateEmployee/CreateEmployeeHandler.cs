namespace nLayer.Application.Employees.Commands.CreateEmployee;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;
using Microsoft.EntityFrameworkCore;

using nLayer.Data;
using nLayer.Data.Entities;
using nLayer.Data.Enums;
using nLayer.Application.DateTime;
using nLayer.Application.Exceptions;

public class CreateEmployeeHandler 
    : IRequestHandler<CreateEmployeeCommand, CreateEmployeeDto>
{
    private readonly ApplicationDbContext context;
    private readonly IDateTimeService dateTimeServiceService;
    private readonly IMapper mapper;

    public CreateEmployeeHandler(
        ApplicationDbContext context, 
        IDateTimeService dateTimeServiceService, 
        IMapper mapper)
    {
        this.context = context;
        this.dateTimeServiceService = dateTimeServiceService;
        this.mapper = mapper;
    }

    public async Task<CreateEmployeeDto> Handle(
        CreateEmployeeCommand request, 
        CancellationToken cancellationToken)
    {
        var valid = Enum
            .TryParse<Gender>(request.Gender, true, out var gender);

        if (!valid)
        {
            throw new InvalidGenderException();
        }

        var employee = new Employee
        {
            Name = request.Name, 
            Age = request.Age, 
            CreatedAt = this.dateTimeServiceService.Now,
            Email = request.Email, 
            Address = request.Address, 
            Gender = gender, 
            Salary = request.Salary, 
            DepartmentId = request.DepartmentId,
            IsActive = true
        };

        await this.context.Employees.AddAsync(employee, cancellationToken);
        await this.context.SaveChangesAsync(cancellationToken);

        return (await this.context.Employees
            .ProjectTo<CreateEmployeeDto>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(
                x => x.Id == employee.Id, 
                cancellationToken))!;
    }
}
