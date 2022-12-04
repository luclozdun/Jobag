using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;

namespace Jobag.src.Resume.Application.DTOs
{
    public class SkillResponse
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }

        public SkillResponse(Skill skill)
        {
            this.Id = skill.Id;
            this.Name = skill.Name;
            this.Description = skill.Description;
        }
    }
}