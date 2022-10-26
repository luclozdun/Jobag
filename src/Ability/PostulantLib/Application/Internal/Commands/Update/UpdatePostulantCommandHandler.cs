using System;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Commands.Update
{
    public class UpdatePostulantCommandHandler : ICommandHandler<UpdatePostulantCommand, PostulantResult>
    {
        private readonly IPostulantRepository postulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public UpdatePostulantCommandHandler(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResult> Handle(UpdatePostulantCommand request, CancellationToken cancellationToken)
        {
            PostulantId id = PostulantId.Create(request.Id);
            PostulantEmail email = PostulantEmail.Create(request.Email);
            PostulantNumber number = PostulantNumber.Create(request.Number);
            PostulantPassword password = PostulantPassword.Create(request.Password);
            PostulantDocument document = PostulantDocument.Create(request.Document);

            Postulant postulant = await postulantRepository.FindPostulantById(id);
            if (postulant == null)
                return new PostulantResult("Postulant not found");

            if (!postulant.Email.Equals(request.Email))
            {
                Postulant existEmail = await postulantRepository.FindPostulantByEmail(email);
                if (existEmail == null)
                    return new PostulantResult("The email is being used");
            }

            if (!postulant.Number.Equals(request.Number))
            {
                Postulant existNumber = await postulantRepository.FindPostulantByNumber(number);
                if (existNumber != null)
                    return new PostulantResult("The number is being used");
            }

            if (!postulant.Document.Equals(request.Document))
            {
                Postulant existDocument = await postulantRepository.FindPostulantByDocument(document);
                if (existDocument != null)
                    return new PostulantResult("The document is being used");
            }

            //postulant.Update(request);

            try
            {
                postulantRepository.UpdatePostulant(postulant);
                await unitOfWork.CompleteAsync();
                return new PostulantResult(postulant);
            }
            catch (Exception e)
            {
                return new PostulantResult($"Error ocurred while update postulant by id: {e.Message}");
            }
        }
    }
}