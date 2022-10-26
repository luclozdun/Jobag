using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Application.Internal.Commands;
using Jobag.src.Ability.PostulantLib.Application.Internal.Commands.Remove;
using Jobag.src.Ability.PostulantLib.Application.Internal.Commands.Update;
using Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindAll;
using Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindPostulantById;
using Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindPostulantInformationById;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Ability.PostulantLib.Application.Controller
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

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            var result = await mediator.Send(new FindPostulantByIdQuery(id));
            return result.Success == true ? Ok(PostulantResponse.Convert(result.Resource)) : BadRequest(result.Message);
        }

        [HttpGet("/info/{id}")]
        public async Task<IActionResult> FindByIdAllInfo([FromRoute] int id)
        {
            PostulantResult result = await mediator.Send(new FindPostulantInformationByIdQuery(id));
            return result.Success == true ? Ok(PostulantInformationResponse.Convert(result.Resource)) : BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IEnumerable<Postulant>> FindAll()
        {
            IEnumerable<Postulant> response = await mediator.Send(new FindAllPostulantQuery());
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostulantRequest request)
        {
            PostulantResult result = await mediator.Send(new CreatePostulantCommand(request));
            return result.Success == true ? Ok(PostulantResponse.Convert(result.Resource)) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            PostulantResult result = await mediator.Send(new RemovePostulantCommand(id));
            return result.Success == true ? Ok(PostulantResponse.Convert(result.Resource)) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PostulantRequest request)
        {
            PostulantResult result = await mediator.Send(new UpdatePostulantCommand(id, request));
            return result.Success == true ? Ok(PostulantResponse.Convert(result.Resource)) : BadRequest(result.Message);
        }
    }
}