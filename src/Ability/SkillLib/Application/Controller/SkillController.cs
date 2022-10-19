using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Resource;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Application.Commands.Bus;
using Jobag.src.Ability.SkillLib.Application.Commands.CreateSkill;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Ability.SkillLib.Domain.Resource;
using Jobag.src.Ability.SkillLib.Infraestructure;
using Jobag.src.Shared.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Ability.SkillLib.Application.Controller
{
    [Route("/skills")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        public readonly ISkillCommands commands;

        public readonly ISkillPostulantRepository skillPostulantRepository;

        public readonly IUnitOfWork unitOfWork;

        public SkillController(ISkillCommands commands, ISkillPostulantRepository skillPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.commands = commands;
            this.skillPostulantRepository = skillPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillCommand command)
        {
            SkillResponse result = await commands.Create(command);
            return result.Success == true ? Ok(SkillResource.Convert(result.Resource)) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(int postulantId, int asd)
        {
            await skillPostulantRepository.AddSkillByIdAndPostulantById(new SkillPostulant(asd, postulantId));
            await unitOfWork.CompleteAsync();
            return Ok("Bien");
        }

        [HttpGet("add")]
        public async Task<IActionResult> GetAdd()
        {
            IList<SkillPostulant> a = await skillPostulantRepository.FindAllSkillByPostulantId(new PostulantId(1));

            return Ok(SkillResource.ConvertToList(a));
        }
    }
}