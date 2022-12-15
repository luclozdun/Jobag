using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Application.DTOs;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.SaveRange
{
    public class SkillPostulantSaveRangeCommand : ICommand<IList<SkillPostulant>>
    {
        public Stack<SkillPostulantId> skillPostulants { get; }

        public SkillPostulantSaveRangeCommand(Stack<SkillPostulantId> request)
        {
            skillPostulants = request;
        }
    }
}