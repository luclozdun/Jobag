using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.Application.Internal.Commands.CourseCommands.Remove
{
    public class CourseRemoveCommand : ICommand<CourseResult>
    {
        public int Id { get; }

        public CourseRemoveCommand(int id)
        {
            Id = id;
        }
    }
}