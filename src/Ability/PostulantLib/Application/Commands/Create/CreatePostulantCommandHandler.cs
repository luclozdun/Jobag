using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Create
{
    internal class CreatePostulantCommandHandler : CommandHandler<CreatePostulantCommand, PostulantResponse>
    {

        private readonly PostulantCreator creator;

        public CreatePostulantCommandHandler(PostulantCreator creator)
        {
            this.creator = creator;
        }

        public async Task<PostulantResponse> Handle(CreatePostulantCommand command)
        {
            PostulantFirstName firstName = PostulantFirstName.Create(command.FirstName);
            PostulantLastName lastName = PostulantLastName.Create(command.LastName);
            PostulantEmail email = PostulantEmail.Create(command.Email);
            PostulantNumber number = PostulantNumber.Create(command.Number);
            PostulantPassword password = PostulantPassword.Create(command.Password);
            PostulantDocument document = PostulantDocument.Create(command.Document);

            PostulantResponse response = await creator.Create(firstName, lastName, email, number, password, document, "asd");
            return response;
        }
    }
}