using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Application.DTOs;
using Jobag.src.Enterprise.Application.Internal.Commands.EmployeeCommands.Remove;
using Jobag.src.Enterprise.Application.Internal.Commands.EmployeeCommands.Update;
using Jobag.src.Enterprise.Application.Internal.Queries.EmployeeQueries.FindByCompanyId;
using Jobag.src.Enterprise.Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Enterprise.Application.Controllers
{
    [Route("/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EmployeeRequest request)
        {
            EmployeeResult result = await mediator.Send(new EmployeeUpdateCommand(id, request));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            EmployeeResult result = await mediator.Send(new EmployeeRemoveCommand(id));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpGet("company/{id}")]
        public async Task<IActionResult> FindByCompanyId([FromRoute] int id)
        {
            return Ok(await mediator.Send(new EmployeeFindByCompanyIdQuery(id)));
        }
    }
}