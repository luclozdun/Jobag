using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Application.DTOs;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillCommands.SkillCreate
{
    public class SkillCreateCommand : ICommand<SkillResult>
    {
        public string Name { get; }
        public string Description { get; }

        public SkillCreateCommand(SkillRequest request)
        {
            Name = request.Name;
            Description = request.Description;
        }
    }
}