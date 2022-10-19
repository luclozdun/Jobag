using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Remove
{
    public class RemovePostulantCommandHandler : CommandHandler<RemovePostulantCommand, PostulantResponse>
    {
        private readonly PostulantRemover remover;

        public RemovePostulantCommandHandler(PostulantRemover remover)
        {
            this.remover = remover;
        }

        public async Task<PostulantResponse> Handle(RemovePostulantCommand command)
        {
            PostulantId id = PostulantId.Create(command.Id);

            PostulantResponse response = await remover.Remove(id);
            return response;
        }
    }
}