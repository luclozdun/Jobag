using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.Application.Internal.Commands.CourseCommands.Create
{
    public class CourseCreateCommand : ICommand<CourseResult>
    {
        public string Name { get; }
        public string Description { get; }

        public CourseCreateCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}