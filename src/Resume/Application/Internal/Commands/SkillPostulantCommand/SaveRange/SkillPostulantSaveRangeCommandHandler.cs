using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.SaveRange
{
    public class SkillPostulantSaveRangeCommandHandler : ICommandHandler<SkillPostulantSaveRangeCommand, IList<SkillPostulant>>
    {
        private readonly ISkillPostulantRepository skillPostulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public SkillPostulantSaveRangeCommandHandler(ISkillPostulantRepository skillPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.skillPostulantRepository = skillPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<SkillPostulant>> Handle(SkillPostulantSaveRangeCommand request, CancellationToken cancellationToken)
        {
            IList<SkillPostulant> skillPostulants = new List<SkillPostulant>();

            Stack<SkillPostulantId> stack = request.skillPostulants;

            while (stack.Count != 0)
            {
                SkillPostulantId val = stack.Pop();
                SkillId skillId = new SkillId(val.SkillId);
                PostulantId postulantId = new PostulantId(val.PostulantId);
                SkillPostulant skillPostulant = new SkillPostulant(skillId, postulantId);
                skillPostulants.Add(skillPostulant);
            }

            await skillPostulantRepository.SaveList(skillPostulants);
            await unitOfWork.CompleteAsync();
            return skillPostulants;

        }
    }
}