using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillCommands.SkillRemove
{
    public class SkillRemoveCommand : ICommand<SkillResult>
    {
        public int Id { get; }

        public SkillRemoveCommand(int id)
        {
            Id = id;
        }
    }
}