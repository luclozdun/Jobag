using System;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Commands.Remove
{
    public class RemovePostulantCommandHandler : ICommandHandler<RemovePostulantCommand, PostulantResult>
    {
        private readonly IPostulantRepository postulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public RemovePostulantCommandHandler(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResult> Handle(RemovePostulantCommand request, CancellationToken cancellationToken)
        {
            PostulantId id = PostulantId.Create(request.Id);

            Postulant existPostulant = await postulantRepository.FindPostulantById(id);
            if (existPostulant == null)
            {
                return new PostulantResult("Postulant not found");
            }

            try
            {
                postulantRepository.DeletePostulant(existPostulant);
                await unitOfWork.CompleteAsync();
                return new PostulantResult(existPostulant);
            }
            catch (Exception e)
            {
                return new PostulantResult($"Error ocurred while remove postulant by id: {e.Message}");
            }
        }
    }
}