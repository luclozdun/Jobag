using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : ICommandHandler<CreateSkillCommand, SkillResult>
    {
        private readonly ISkillRepository skillRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateSkillCommandHandler(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            this.skillRepository = skillRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillResult> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            Skill existName = await skillRepository.FindSkillByName(request.Name);
            if (existName != null)
                return new SkillResult("This name is being used");

            Skill skill = Skill.Create(request.Name, request.Description);

            try
            {
                await skillRepository.CreateSkill(skill);
                await unitOfWork.CompleteAsync();
                return new SkillResult(skill);
            }
            catch (Exception e)
            {
                return new SkillResult($"Error ocurred while saving the skill: {e.Message}");
            }
        }
    }
}