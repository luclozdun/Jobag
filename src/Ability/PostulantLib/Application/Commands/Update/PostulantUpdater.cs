using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Update
{
    public class PostulantUpdater
    {
        private readonly IPostulantRepository postulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public PostulantUpdater(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResponse> Update(PostulantId id, PostulantFirstName firstName, PostulantLastName lastName, PostulantEmail email, PostulantNumber number, PostulantPassword password, PostulantDocument document, string civilStatus)
        {
            Postulant postulant = await postulantRepository.FindPostulantById(id);
            if (postulant == null)
                return new PostulantResponse("Postulant not found");

            Postulant existEmail = await postulantRepository.FindPostulantByEmail(email);
            if (postulant == null)
                return new PostulantResponse("The email is being used");

            Postulant existNumber = await postulantRepository.FindPostulantByNumber(number);
            if (existNumber != null)
                return new PostulantResponse("The number is being used");

            Postulant existDocument = await postulantRepository.FindPostulantByDocument(document);
            if (existDocument != null)
                return new PostulantResponse("The document is being used");

            postulant.setId(id);
            postulant.SetCivilStatus(civilStatus);
            postulant.SetDocument(document);
            postulant.SetEmail(email);
            postulant.SetFirstName(firstName);
            postulant.SetLastName(lastName);
            postulant.SetNumber(number);
            postulant.SetPassword(password);

            try
            {
                postulantRepository.UpdatePostulant(postulant);
                await unitOfWork.CompleteAsync();
                return new PostulantResponse(postulant);
            }
            catch (Exception e)
            {
                return new PostulantResponse($"Error ocurred while update postulant by id: {e.Message}");
            }
        }
    }
}