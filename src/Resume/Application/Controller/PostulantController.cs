using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Application.DTOs;
using Jobag.src.Resume.Application.Internal.Commands.PostulantCommands.PostulantRemove;
using Jobag.src.Resume.Application.Internal.Commands.PostulantCommands.PostulantSignIn;
using Jobag.src.Resume.Application.Internal.Commands.PostulantCommands.PostulantUpdate;
using Jobag.src.Resume.Application.Internal.Queries.PostulantQueries.PostulantInformation;
using Jobag.src.Resume.Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Resume.Application.Controller
{
    [Route("/postulants")]
    [ApiController]
    public class PostulantController : ControllerBase
    {
        public readonly IMediator mediator;

        public PostulantController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostulantRequest request)
        {
            PostulantResult result = await mediator.Send(new PostulantSignInCommand(request));

            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PostulantRequest request, [FromRoute] int id)
        {
            PostulantResult result = await mediator.Send(new PostulantUpdateCommand(id, request));

            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            PostulantResult result = await mediator.Send(new PostulantRemoveCommand(id));

            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            PostulantResult result = await mediator.Send(new PostulantInformationQuery(id));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}