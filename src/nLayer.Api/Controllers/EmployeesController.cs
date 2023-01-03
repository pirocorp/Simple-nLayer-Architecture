namespace nLayer.Api.Controllers;

using Application.Employees.Commands.FireEmployee;

using Microsoft.AspNetCore.Mvc;

using nLayer.Application.Employees.Commands.CreateEmployee;
using nLayer.Application.Employees.Commands.UpdateEmployee;
using nLayer.Application.Employees.Queries.GetEmployees;
using nLayer.Application.Employees.Queries.GetEmployeesById;

public class EmployeesController : ApiControllerBase
{
    [HttpGet(WITH_ID)]
    public async Task<ActionResult<GetEmployeesByIdDto>> GetById(int id)
        => this.OkOrNotFound(
            await this.Mediator.Send(new GetEmployeesByIdQuery(id)));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetEmployeesListingDto>>> GetEmployees()
        => this.Ok(await this.Mediator.Send(new GetEmployeesQuery()));

    [HttpPost]
    public async Task<ActionResult<CreateEmployeeDto>> CreateEmployee(
        CreateEmployeeCommand input,
        CancellationToken cancellationToken)
            => await this.Mediator.Send(input, cancellationToken);

    [HttpDelete(WITH_ID)]
    public async Task<ActionResult<FireEmployeeDto>> FireEmployee(
        int id,
        CancellationToken cancellationToken)
            => await this.Mediator.Send(
                new FireEmployeeCommand(id), 
                cancellationToken);

    [HttpPost(WITH_ID)]
    public async Task<ActionResult<UpdateEmployeeDto>> UpdateEmployee(
        int id,
        UpdateEmployeeCommand input,
        CancellationToken cancellationToken)
    {
        input = input with { Id = id };

        var response = await this.Mediator
            .Send(input, cancellationToken);

        return this.OkOrNotFound(response);
    }
}
