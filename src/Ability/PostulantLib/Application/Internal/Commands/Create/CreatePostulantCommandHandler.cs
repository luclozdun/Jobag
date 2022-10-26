using System;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Commands.Create
{
    internal class CreatePostulantCommandHandler : ICommandHandler<CreatePostulantCommand, PostulantResult>
    {

        private readonly IPostulantRepository postulantReposity;
        private readonly IUnitOfWork unitOfWork;

        public CreatePostulantCommandHandler(IPostulantRepository postulantReposity, IUnitOfWork unitOfWork)
        {
            this.postulantReposity = postulantReposity;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResult> Handle(CreatePostulantCommand request, CancellationToken cancellationToken)
        {
            PostulantEmail email = PostulantEmail.Create(request.Email);
            PostulantNumber number = PostulantNumber.Create(request.Number);
            PostulantPassword password = PostulantPassword.Create(request.Password);
            PostulantDocument document = PostulantDocument.Create(request.Document);

            Postulant existEmail = await postulantReposity.FindPostulantByEmail(email);
            if (existEmail != null)
                return new PostulantResult("The email is being used");

            Postulant existNumber = await postulantReposity.FindPostulantByNumber(number);
            if (existNumber != null)
                return new PostulantResult("The number is being used");

            Postulant existDocument = await postulantReposity.FindPostulantByDocument(document);
            if (existDocument != null)
                return new PostulantResult("The document is being used");


            Postulant postulant = Postulant.Create(request.FirstName, request.LastName, email, number, password, document, "civilStatus");

            try
            {
                await postulantReposity.AddPostulant(postulant);
                await unitOfWork.CompleteAsync();
                return new PostulantResult(postulant);
            }
            catch (Exception e)
            {
                return new PostulantResult($"Error ocurred while saving the postulant: {e.Message}");
            }
        }
    }
}