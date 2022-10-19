using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Create
{
    public class PostulantCreator
    {
        private readonly IPostulantRepository postulantReposity;
        private readonly IUnitOfWork unitOfWork;

        public PostulantCreator(IPostulantRepository postulantReposity, IUnitOfWork unitOfWork)
        {
            this.postulantReposity = postulantReposity;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResponse> Create(PostulantFirstName firstName, PostulantLastName lastName, PostulantEmail email, PostulantNumber number, PostulantPassword password, PostulantDocument document, string civilStatus)
        {
            var existEmail = await postulantReposity.FindPostulantByEmail(email);
            if (existEmail != null)
                return new PostulantResponse("The email is being used");

            var existNumber = await postulantReposity.FindPostulantByNumber(number);
            if (existNumber != null)
                return new PostulantResponse("The number is being used");

            var existDocument = await postulantReposity.FindPostulantByDocument(document);
            if (existDocument != null)
                return new PostulantResponse("The document is being used");


            Postulant postulant = Postulant.Create(firstName, lastName, email, number, password, document, civilStatus);

            try
            {
                await postulantReposity.AddPostulant(postulant);
                await unitOfWork.CompleteAsync();
                return new PostulantResponse(postulant);
            }
            catch (Exception e)
            {
                return new PostulantResponse($"Error ocurred while saving the postulant: {e.Message}");
            }


        }
    }
}