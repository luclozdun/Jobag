using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Application.DTOs;
using Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkill;
using Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkillPostulant;
using Jobag.src.Ability.SkillLib.Application.Internal.Commands.RemoveSkill;
using Jobag.src.Ability.SkillLib.Application.Internal.Commands.UpdateSkill;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Ability.SkillLib.Application.Controller
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
        public async Task<IActionResult> Create(SkillRequest request)
        {
            SkillResult result = await mediator.Send(new CreateSkillCommand(request));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpPut("{skillId}")]
        public async Task<IActionResult> Update([FromRoute] int skillId, [FromBody] SkillRequest request)
        {
            SkillResult result = await mediator.Send(new UpdateSkillCommand(skillId, request));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpDelete("{skillId}")]
        public async Task<IActionResult> Remove([FromRoute] int skillId, [FromBody] SkillRequest request)
        {
            SkillResult result = await mediator.Send(new RemoveSkillCommand(skillId));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}