using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Update
{
    public class UpdatePostulantCommandHandler : UCommandHandler<UpdatePostulantCommand, PostulantResponse>
    {
        private readonly PostulantUpdater updater;

        public UpdatePostulantCommandHandler(PostulantUpdater updater)
        {
            this.updater = updater;
        }

        public async Task<PostulantResponse> Handle(int _id, UpdatePostulantCommand command)
        {
            PostulantId id = PostulantId.Create(_id);
            PostulantFirstName firstName = PostulantFirstName.Create(command.FirstName);
            PostulantLastName lastName = PostulantLastName.Create(command.LastName);
            PostulantEmail email = PostulantEmail.Create(command.Email);
            PostulantNumber number = PostulantNumber.Create(command.Number);
            PostulantPassword password = PostulantPassword.Create(command.Password);
            PostulantDocument document = PostulantDocument.Create(command.Document);

            PostulantResponse response = await updater.Update(id, firstName, lastName, email, number, password, document, "");
            return response;
        }
    }
}