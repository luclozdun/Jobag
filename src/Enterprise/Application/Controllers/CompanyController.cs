using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Application.DTOs;
using Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.AddEmployee;
using Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Create;
using Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Remove;
using Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Update;
using Jobag.src.Enterprise.Application.Internal.Queries.CompanyQueries.FindAll;
using Jobag.src.Enterprise.Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Enterprise.Application.Controllers
{
    [Route("/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public IMediator mediator;

        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyRequest request)
        {
            CompanyResult result = await mediator.Send(new CompanyCreateCommand(request));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpPost("{id}/employee")]
        public async Task<IActionResult> AddPostulant([FromBody] EmployeeRequest request, [FromRoute] int id)
        {
            EmployeeResult result = await mediator.Send(new AddEmployeeCommand(request, id));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CompanyRequest request)
        {
            CompanyResult result = await mediator.Send(new CompanyUpdateCommand(id, request));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            CompanyResult result = await mediator.Send(new CompanyRemoveCommand(id));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await mediator.Send(new CompanyFindAllQuery()));
        }
    }
}