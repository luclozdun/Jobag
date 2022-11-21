using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Ability.Application.DTOs
{
    public class SkillResponse
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }

        public SkillResponse(int Id, string Name, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }
    }
}