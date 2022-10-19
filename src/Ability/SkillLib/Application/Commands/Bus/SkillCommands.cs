using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Application.Commands.CreateSkill;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.SkillLib.Application.Commands.Bus
{
    public class SkillCommands : ISkillCommands
    {
        private readonly ISkillRepository skillRepository;
        private readonly IUnitOfWork unitOfWork;

        public SkillCommands(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            this.skillRepository = skillRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillResponse> Create(CreateSkillCommand command)
        {
            CreateSkillCommandHandler handler = new CreateSkillCommandHandler(new SkillCreator(skillRepository, unitOfWork));
            return await handler.Handle(command);
        }
    }
}