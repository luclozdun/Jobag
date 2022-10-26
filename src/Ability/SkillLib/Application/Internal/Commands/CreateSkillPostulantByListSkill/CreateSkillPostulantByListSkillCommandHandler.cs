using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkillPostulantByListSkill
{
    public class CreateSkillPostulantByListSkillCommandHandler : ICommandHandler<CreateListSkillPostulantCommand, ListSkillPostulantResult>
    {
        private readonly ISkillPostulantRepository skillPostulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public CreateSkillPostulantByListSkillCommandHandler(ISkillPostulantRepository skillPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.skillPostulantRepository = skillPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ListSkillPostulantResult> Handle(CreateListSkillPostulantCommand request, CancellationToken cancellationToken)
        {
            List<SkillPostulant> skillPostulants = new List<SkillPostulant>();

            foreach (int skillId in request.skillIds)
            {
                skillPostulants.Add(new SkillPostulant(SkillId.Create(skillId), PostulantId.Create(request.postulantId)));
            }

            try
            {
                await skillPostulantRepository.AddSkillPostulantByPostulantIdAndListSkillId(skillPostulants);
                await unitOfWork.CompleteAsync();
                return new ListSkillPostulantResult(skillPostulants);
            }
            catch (Exception e)
            {
                return new ListSkillPostulantResult($"Error ocurred while creating list skill postulant: {e.Message}");
            }
        }
    }
}