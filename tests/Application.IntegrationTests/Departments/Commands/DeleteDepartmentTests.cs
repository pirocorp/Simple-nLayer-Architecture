namespace Application.IntegrationTests.Departments.Commands;

using Application.IntegrationTests;
using AutoMapper;

using FluentAssertions;
using FluentAssertions.Execution;
using MediatR;
using Moq;
using nLayer.Application.Departments.Commands.DeleteDepartment;
using nLayer.Application.Departments.Events.DeleteDepartment;
using nLayer.Data;
using nLayer.Data.Entities;

public class DeleteDepartmentTests : BaseTests
{
    private readonly IMapper mapper;
    private readonly Mock<IMediator> mediator;
    
    private ApplicationDbContext context;
    private DeleteDepartmentHandler commandHandler;

    public DeleteDepartmentTests()
    {
        this.mapper = this.GetMapper();
        this.mediator = this.GetMediator();

        this.context = null!;
        this.commandHandler = null!;
    }

    [SetUp]
    public void SetUp()
    {
        this.context = this.GetDatabase();
        this.commandHandler = new DeleteDepartmentHandler(
            this.context,
            this.mapper,
            this.mediator.Object);
    }

    [Test]
    public void DeleteDepartmentCommandHandlerIsCreatedCorrectly()
        => this.commandHandler
            .Should()
            .NotBeNull();

    [Test]
    public async Task DeleteDepartmentWorksCorrectly()
    {
        var department1 = new Department
        {
            Name = "IT", 
            CreatedAt = DateTime.Now, 
            IsActive = true
        };

        var department2 = new Department
        {
            Name = "HR", 
            CreatedAt = DateTime.Now, 
            IsActive = true
        };

        this.context.Departments.Add(department1);
        this.context.Departments.Add(department2);

        var cts = new CancellationTokenSource();
        await this.context.SaveChangesAsync(cts.Token);

        var command = new DeleteDepartmentCommand(department1.Id);

        var response = await this.commandHandler
            .Handle(command, cts.Token);

        using (new AssertionScope())
        {
            response.Should().NotBeNull();
            department1.IsActive.Should().BeFalse();

            this.mediator.Verify(
                x => x.Publish(
                    It.IsAny<DepartmentDeletedEvent>(), 
                    cts.Token));
        }
    }

    [Test]
    public async Task DeleteDepartmentReturnsNullIfNoDepartmentIsFound()
    {
        var department1 = new Department
        {
            Name = "IT", 
            CreatedAt = DateTime.Now, 
            IsActive = true
        };

        var department2 = new Department
        {
            Name = "HR", 
            CreatedAt = DateTime.Now, 
            IsActive = true
        };

        this.context.Departments.Add(department1);
        this.context.Departments.Add(department2);

        var cts = new CancellationTokenSource();
        await this.context.SaveChangesAsync(cts.Token);

        var command = new DeleteDepartmentCommand(-1);

        var response = await this.commandHandler
            .Handle(command, cts.Token);

        response.Should().BeNull();
    }

    [Test]
    public async Task DeleteDepartmentShouldThrowWithCanceledToken()
    {
        var department1 = new Department
        {
            Name = "IT", 
            CreatedAt = DateTime.Now, 
            IsActive = true
        };

        this.context.Departments.Add(department1);

        var cts = new CancellationTokenSource();
        await this.context.SaveChangesAsync(cts.Token);

        var input = new DeleteDepartmentCommand(department1.Id);

        cts.Cancel();

        await FluentActions.Invoking(async () 
                => await this.commandHandler.Handle(input, cts.Token))
            .Should()
            .ThrowAsync<OperationCanceledException>();
    }
}
