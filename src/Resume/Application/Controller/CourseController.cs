using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Application.DTOs;
using Jobag.src.Resume.Application.Internal.Commands.CourseCommands.Create;
using Jobag.src.Resume.Application.Internal.Commands.CourseCommands.Remove;
using Jobag.src.Resume.Application.Internal.Queries.CourseQueries.FindAll;
using Jobag.src.Resume.Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Resume.Application.Controller
{
    [Route("/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly IMediator mediator;

        public CourseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseRequest request)
        {
            CourseResult result = await mediator.Send(new CourseCreateCommand(request));
            return result.Success ? Ok(new CourseResponse(result.Resource)) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int Id)
        {
            CourseResult result = await mediator.Send(new CourseRemoveCommand(Id));
            return result.Success ? Ok(new CourseResponse(result.Resource)) : BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await mediator.Send(new CourseFindAllQuery()));
        }
    }
}