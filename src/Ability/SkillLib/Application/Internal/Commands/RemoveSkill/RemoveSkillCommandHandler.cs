using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.RemoveSkill
{
    public class RemoveSkillCommandHandler : ICommandHandler<RemoveSkillCommand, SkillResult>
    {
        private readonly ISkillRepository skillRepository;

        private readonly IUnitOfWork unitOfWork;

        public RemoveSkillCommandHandler(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            this.skillRepository = skillRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillResult> Handle(RemoveSkillCommand request, CancellationToken cancellationToken)
        {
            SkillId skillId = new SkillId(request.Id);
            Skill skill = await skillRepository.FindSkillById(skillId);
            if (skill == null)
            {
                return new SkillResult("Skill not found");
            }

            try
            {
                skillRepository.RemoveSkill(skill);
                await unitOfWork.CompleteAsync();
                return new SkillResult(skill);
            }
            catch (Exception e)
            {
                return new SkillResult($"Error ocurred while remove skill by id: {e.Message}");
            }
        }
    }
}