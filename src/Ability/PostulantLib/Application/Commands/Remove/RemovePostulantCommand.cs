using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Remove
{
    public class RemovePostulantCommand : Command
    {
        public int Id { get; private set; }

        public RemovePostulantCommand(int id)
        {
            Id = id;
        }
    }
}