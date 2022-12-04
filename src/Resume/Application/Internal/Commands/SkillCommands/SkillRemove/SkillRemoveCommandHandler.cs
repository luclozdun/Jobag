using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillCommands.SkillRemove
{
    public class SkillRemoveCommandHandler : ICommandHandler<SkillRemoveCommand, SkillResult>
    {
        private readonly ISkillRepository skillRepository;

        private readonly IUnitOfWork unitOfWork;

        public SkillRemoveCommandHandler(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            this.skillRepository = skillRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillResult> Handle(SkillRemoveCommand request, CancellationToken cancellationToken)
        {
            SkillId skillId = new SkillId(request.Id);
            Skill skill = await skillRepository.FindById(skillId);

            if (skill == null)
                return new SkillResult("Skill not found");

            try
            {
                skillRepository.Remove(skill);
                await unitOfWork.CompleteAsync();
                return new SkillResult(skill);
            }
            catch (Exception e)
            {
                return new SkillResult($"Error ocurred while removing skill: {e.Message}");
            }
        }
    }
}