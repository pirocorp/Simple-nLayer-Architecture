namespace nLayer.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

using nLayer.Application.Departments.Commands.CreateDepartment;
using nLayer.Application.Departments.Commands.DeleteDepartment;
using nLayer.Application.Departments.Commands.RenameDepartment;
using nLayer.Application.Departments.Queries.GetDepartments;
using nLayer.Application.Departments.Queries.GetDepartmentsById;

public class DepartmentsController : ApiControllerBase
{
    [HttpGet(WITH_ID)]
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

    [HttpPatch(WITH_ID)]
    public async Task<ActionResult<RenameDepartmentDetailsDto>> RenameDepartment(
        int id,
        RenameDepartmentCommand command,
        CancellationToken cancellationToken)
    {
        command = command with { Id = id };
        var response = await this.Mediator
            .Send(command, cancellationToken);

        return this.OkOrNotFound(response);
    }

    [HttpDelete(WITH_ID)]
    public async Task<ActionResult<DeleteDepartmentDetailsDto>> Delete(int id, CancellationToken cancellationToken)
        => this.OkOrNotFound(
            await this.Mediator.Send(
                new DeleteDepartmentCommand(id), 
                cancellationToken));
}
