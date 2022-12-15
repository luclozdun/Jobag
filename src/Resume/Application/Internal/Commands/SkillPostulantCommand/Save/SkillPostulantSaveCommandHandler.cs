using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Resume.Domain.Model.ValueObjects;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.Save
{
    public class SkillPostulantSaveCommandHandler : ICommandHandler<SkillPostulantSaveCommand, SkillPostulantResult>
    {
        private readonly ISkillPostulantRepository skillPostulantRepository;
        private readonly IUnitOfWork unitOfWork;

        public SkillPostulantSaveCommandHandler(ISkillPostulantRepository skillPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.skillPostulantRepository = skillPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillPostulantResult> Handle(SkillPostulantSaveCommand request, CancellationToken cancellationToken)
        {
            SkillId skillId = new SkillId(request.SkillId);
            PostulantId postulantId = new PostulantId(request.PostulantId);
            SkillPostulant skillPostulant = new SkillPostulant(skillId, postulantId);

            try
            {
                await skillPostulantRepository.Save(skillPostulant);
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