using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.SkillLib.Application.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : CommandHandler<CreateSkillCommand, SkillResponse>
    {
        private readonly SkillCreator creator;

        public CreateSkillCommandHandler(SkillCreator creator)
        {
            this.creator = creator;
        }

        public async Task<SkillResponse> Handle(CreateSkillCommand command)
        {
            SkillName name = SkillName.Create(command.Name);
            SkillDescription description = SkillDescription.Create(command.Description);
            var response = await creator.Create(name, description);
            return response;
        }
    }
}