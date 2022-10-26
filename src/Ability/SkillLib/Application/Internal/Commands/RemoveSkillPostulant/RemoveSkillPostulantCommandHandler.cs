using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.RemoveSkillPostulant
{
    public class RemoveSkillPostulantCommandHandler : ICommandHandler<RemoveSkillPostulantCommand, SkillPostulantResult>
    {
        private readonly ISkillPostulantRepository skillPostulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public RemoveSkillPostulantCommandHandler(ISkillPostulantRepository skillPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.skillPostulantRepository = skillPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillPostulantResult> Handle(RemoveSkillPostulantCommand request, CancellationToken cancellationToken)
        {
            SkillPostulant skillPostulant = await skillPostulantRepository.FindSkillPostulantBySkillIdAndPostulantId(new PostulantId(request.postulantId), new SkillId(request.skillId));
            if (skillPostulant == null)
            {
                return new SkillPostulantResult("Skill postulant not found by postulant and skill id");
            }

            try
            {
                skillPostulantRepository.RemoveSkillPostulant(skillPostulant);
                await unitOfWork.CompleteAsync();
                return new SkillPostulantResult(skillPostulant);
            }
            catch (Exception e)
            {
                return new SkillPostulantResult($"Error ocurred while removing by id: {e.Message}");
            }

        }
    }
}