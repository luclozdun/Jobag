using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Resume.Application.Internal.Commands.PostulantCommands.PostulantRemove
{
    public class PostulantRemoveCommandHandler : ICommandHandler<PostulantRemoveCommand, PostulantResult>
    {
        private readonly IPostulantRepository postulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public PostulantRemoveCommandHandler(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResult> Handle(PostulantRemoveCommand request, CancellationToken cancellationToken)
        {
            PostulantId postulantId = new PostulantId(request.Id);
            Postulant postulant = await postulantRepository.FindById(postulantId);

            if (postulant == null)
                return new PostulantResult("Postulant not found");

            try
            {
                postulantRepository.Remove(postulant);
                await unitOfWork.CompleteAsync();
                return new PostulantResult(postulant);
            }
            catch (Exception e)
            {
                return new PostulantResult($"Error ocurred while removing postulant: {e.Message}");
            }
        }
    }
}