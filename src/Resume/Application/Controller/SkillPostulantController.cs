using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.Remove;
using Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.Save;
using Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.SaveRange;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Resume.Application.Controller
{
    [Route("/skillpostulants")]
    [ApiController]
    public class SkillPostulantController : ControllerBase
    {
        private readonly IMediator mediator;

        public SkillPostulantController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("/postulant/{postulantId}/skill/{skillId}")]
        public async Task<IActionResult> AddPostulantIdAndSkillId([FromRoute] int postulantId, [FromRoute] int skillId)
        {
            SkillPostulantResult result = await mediator.Send(new SkillPostulantSaveCommand(postulantId, skillId));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> AddPostulantIdAndSkillId([FromBody] Stack<SkillPostulantId> request)
        {
            IList<SkillPostulant> result = await mediator.Send(new SkillPostulantSaveRangeCommand(request));
            return Ok(result);
        }

        [HttpDelete("/postulant/{postulantId}/skill/{skillId}")]
        public async Task<IActionResult> Remove([FromRoute] int postulantId, [FromRoute] int skillId){
            SkillPostulantResult result = await mediator.Send(new SkillPostulantRemoveCommand(skillId, postulantId));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}