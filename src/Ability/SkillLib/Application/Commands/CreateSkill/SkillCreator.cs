using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.SkillLib.Application.Commands.CreateSkill
{
    public class SkillCreator
    {
        private readonly ISkillRepository skillRepository;
        private readonly IUnitOfWork unitOfWork;

        public SkillCreator(ISkillRepository skillRepository, IUnitOfWork unitOfWork)
        {
            this.skillRepository = skillRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SkillResponse> Create(SkillName name, SkillDescription description)
        {
            var existName = await skillRepository.FindSkillByName(name);
            if (existName != null)
                return new SkillResponse("This name is being used");

            Skill skill = Skill.Create(name, description);

            try
            {
                await skillRepository.CreateSkill(skill);
                await unitOfWork.CompleteAsync();
                return new SkillResponse(skill);
            }
            catch (Exception e)
            {
                return new SkillResponse($"Error ocurred while saving the skill: {e.Message}");
            }
        }
    }
}