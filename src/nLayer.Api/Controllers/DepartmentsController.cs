namespace nLayer.Api.Controllers;

using Application.Departments.Commands.DeleteDepartment;
using Microsoft.AspNetCore.Mvc;

using nLayer.Application.Departments.Queries.GetDepartments;
using nLayer.Application.Departments.Queries.GetDepartmentsById;
using nLayer.Application.Departments.Commands.CreateDepartment;
using nLayer.Application.Departments.Commands.RenameDepartment;

public class DepartmentsController : ApiControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<DepartmentFullDetailsDto>> GetById(
        int id,
        CancellationToken cancellationToken)
            => this.OkOrNotFound(await this.Mediator
                .Send(new GetDepartmentsByIdQuery(id), cancellationToken));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentListingDto>>> GetDepartments(
        CancellationToken cancellationToken)
            => this.Ok(await this.Mediator
                    .Send(new GetDepartmentsQuery(), cancellationToken));

    [HttpPost]
    public async Task<ActionResult<CreateDepartmentDetailsDto>> CreateDepartment(
        CreateDepartmentCommand input,
        CancellationToken cancellationToken)
            => await this.Mediator.Send(input, cancellationToken);

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<RenameDepartmentDetailsDto>> RenameDepartment(
        int id,
        RenameDepartmentCommand command,
        CancellationToken cancellationToken)
    {
        command.Id = id;
        var response = await this.Mediator
            .Send(command, cancellationToken);

        return this.OkOrNotFound(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DeleteDepartmentDetailsDto>> Delete(int id, CancellationToken cancellationToken)
        => this.OkOrNotFound(
            await this.Mediator.Send(
                new DeleteDepartmentCommand() { Id = id }, 
                cancellationToken));
}
