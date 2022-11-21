using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Result;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.Application.Internal.Commands.PostulantCommands.PostulantUpdate
{
    public class PostulantUpdateCommandHandler : ICommandHandler<PostulantUpdateCommand, PostulantResult>
    {
        private readonly IPostulantRepository postulantRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostulantUpdateCommandHandler(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResult> Handle(PostulantUpdateCommand request, CancellationToken cancellationToken)
        {
            PostulantId postulantId = new PostulantId(request.Id);

            PostulantResult result = await Postulant.Update(postulantId, request.FirstName, request.LastName, request.Email, request.Phone, request.Password, request.Document, postulantRepository);

            if (!result.Success)
                return result;

            try
            {
                postulantRepository.Update(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                return new PostulantResult($"Error ocurred while updating postulant: {e.Message}");
            }
        }
    }
}