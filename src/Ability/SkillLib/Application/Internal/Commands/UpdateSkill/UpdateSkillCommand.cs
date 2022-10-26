using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Application.DTOs;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.UpdateSkill
{
    public class UpdateSkillCommand : ICommand<SkillResult>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public UpdateSkillCommand(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public UpdateSkillCommand(int Id, SkillRequest request)
        {
            this.Id = Id;
            this.Name = request.Name;
            this.Description = request.Description;
        }

    }
}