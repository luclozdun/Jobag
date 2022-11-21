using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.Application.Internal.Commands.PostulantCommands.PostulantRemove
{
    public class PostulantRemoveCommand : ICommand<PostulantResult>
    {
        public int Id { get; }

        public PostulantRemoveCommand(int id)
        {
            Id = id;
        }
    }
}