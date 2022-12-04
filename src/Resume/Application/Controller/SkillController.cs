using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Application.DTOs;
using Jobag.src.Resume.Application.Internal.Commands.CourseCommands.Create;
using Jobag.src.Resume.Application.Internal.Commands.SkillCommands.SkillCreate;
using Jobag.src.Resume.Application.Internal.Commands.SkillCommands.SkillRemove;
using Jobag.src.Resume.Application.Internal.Queries.SkillQueries.FindAll;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Resume.Application.Controller
{
    [Route("/skills")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        public readonly IMediator mediator;

        public SkillController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillRequest request)
        {
            SkillResult result = await mediator.Send(new SkillCreateCommand(request));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int Id)
        {
            SkillResult result = await mediator.Send(new SkillRemoveCommand(Id));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await mediator.Send(new SkillFindAllQuery()));
        }
    }
}