using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Application.DTOs;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkill
{
    public class CreateSkillCommand : ICommand<SkillResult>
    {
        public CreateSkillCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public CreateSkillCommand(SkillRequest request)
        {
            Name = request.Name;
            Description = request.Description;
        }

        public static CreateSkillCommand Convert()
        {
            return new CreateSkillCommand("asd", "asd");
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}