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

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkillPostulant
{
    public class CreateSkillPostulantCommandHandler : ICommandHandler<CreateSkillPostulantCommand, SkillPostulantResult>
    {

        private readonly ISkillPostulantRepository skillPostulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public CreateSkillPostulantCommandHandler(ISkillPostulantRepository skillPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.skillPostulantRepository = skillPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillPostulantResult> Handle(CreateSkillPostulantCommand request, CancellationToken cancellationToken)
        {
            SkillPostulant skillPostulant = new SkillPostulant(SkillId.Create(request.skillId), PostulantId.Create(request.postulantId));

            try
            {
                await skillPostulantRepository.AddSkillByIdAndPostulantById(skillPostulant);
                await unitOfWork.CompleteAsync();
                return new SkillPostulantResult(skillPostulant);
            }
            catch (Exception e)
            {
                return new SkillPostulantResult($"Error ocurred while attach the skill in postulant {e}");
            }
        }
    }
}