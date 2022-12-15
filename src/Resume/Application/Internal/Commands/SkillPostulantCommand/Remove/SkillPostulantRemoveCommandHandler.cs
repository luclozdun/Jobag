using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.Remove
{
    public class SkillPostulantRemoveCommandHandler : ICommandHandler<SkillPostulantRemoveCommand, SkillPostulantResult>
    {
        private readonly ISkillPostulantRepository skillPostulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public SkillPostulantRemoveCommandHandler(ISkillPostulantRepository skillPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.skillPostulantRepository = skillPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillPostulantResult> Handle(SkillPostulantRemoveCommand request, CancellationToken cancellationToken)
        {
            SkillPostulant skillPostulant = await skillPostulantRepository.FindBySkillIdAndPostulantId(request.SkillId, request.PostulantId);
            if (skillPostulant == null)
            {
                return new SkillPostulantResult("Skill postulant not found");
            }

            try
            {
                skillPostulantRepository.Remove(skillPostulant);
                await unitOfWork.CompleteAsync();
                return new SkillPostulantResult(skillPostulant);
            }
            catch (Exception e)
            {
                return new SkillPostulantResult($"Error ocurred while removing skill postulant: {e.Message}");
            }

        }
    }
}