using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Remove
{
    public class PostulantRemover
    {
        private readonly IPostulantRepository postulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public PostulantRemover(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResponse> Remove(PostulantId id)
        {

            Postulant existPostulant = await postulantRepository.FindPostulantById(id);
            if (existPostulant == null)
            {
                return new PostulantResponse("Postulant not found");
            }

            try
            {
                postulantRepository.DeletePostulant(existPostulant);
                await unitOfWork.CompleteAsync();
                return new PostulantResponse(existPostulant);
            }
            catch (Exception e)
            {
                return new PostulantResponse($"Error ocurred while remove postulant by id: {e.Message}");
            }
        }
    }
}