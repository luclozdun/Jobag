using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillCommands.SkillCreate
{
    public class SkillCreateCommandHandler : ICommandHandler<SkillCreateCommand, SkillResult>
    {
        private readonly ISkillRepository skillRepository;

        private readonly IUnitOfWork unitOfWork;

        public SkillCreateCommandHandler(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            this.skillRepository = skillRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillResult> Handle(SkillCreateCommand request, CancellationToken cancellationToken)
        {
            Skill existName = await skillRepository.FindByName(request.Name.ToLower());

            if (existName != null)
                return new SkillResult("The name is being used");

            Skill skill = Skill.Create(request.Name.ToLower(), request.Description);

            try
            {
                await skillRepository.Save(skill);
                await unitOfWork.CompleteAsync();
                return new SkillResult(skill);
            }
            catch (Exception e)
            {
                return new SkillResult($"Error ocurred while saving skill: {e.Message}");
            }

        }
    }
}