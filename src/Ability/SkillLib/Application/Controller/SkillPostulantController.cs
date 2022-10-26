using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Application.DTOs;
using Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkillPostulant;
using Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkillPostulantByListSkill;
using Jobag.src.Ability.SkillLib.Application.Internal.Commands.RemoveSkillPostulant;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Ability.SkillLib.Application.Controller
{
    [Route("/skillpostulants")]
    [ApiController]
    public class SkillPostulantController : ControllerBase
    {
        public readonly IMediator mediator;

        public SkillPostulantController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddSkillIdAndPostulantId([FromBody] SkillPostulantRequest request)
        {
            SkillPostulantResult result = await mediator.Send(new CreateSkillPostulantCommand(request.postulantId, request.skillId));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpPost("list")]
        public async Task<IActionResult> AddSkillIdsAndPostulantId([FromBody] ListSkillIdAndPostulantIdRequest request)
        {
            ListSkillPostulantResult result = await mediator.Send(new CreateListSkillPostulantCommand(request.postulantId, request.skillIds));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBySkillIdAndPostulantId([FromBody] SkillPostulantRequest request)
        {
            SkillPostulantResult result = await mediator.Send(new RemoveSkillPostulantCommand(request.postulantId, request.skillId));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}