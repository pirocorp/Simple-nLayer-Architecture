namespace nLayer.Application.Departments.Commands.CreateDepartment;

using AutoMapper;

using MediatR;

using nLayer.Application.DateTime;
using nLayer.Data;
using nLayer.Data.Entities;

public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentDetailsDto>
{
    private readonly ApplicationDbContext context;
    private readonly IDateTimeService dateTimeService;
    private readonly IMapper mapper;

    public CreateDepartmentHandler(
        ApplicationDbContext context, 
        IDateTimeService dateTimeService, 
        IMapper mapper)
    {
        this.context = context;
        this.dateTimeService = dateTimeService;
        this.mapper = mapper;
    }

    public async Task<CreateDepartmentDetailsDto> Handle(
        CreateDepartmentCommand request, 
        CancellationToken cancellationToken)
    {
        var department = new Department
        {
            Name = request.Name,
            CreatedAt = this.dateTimeService.Now,
            IsActive = true
        };

        await this.context.Departments.AddAsync(department, cancellationToken);
        await this.context.SaveChangesAsync(cancellationToken);

        return this.mapper.Map<CreateDepartmentDetailsDto>(department);
    }
}
