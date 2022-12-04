using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Resume.Application.Internal.Commands.PostulantCommands.PostulantSignIn
{
    public class PostulantSignInCommandHandler : ICommandHandler<PostulantSignInCommand, PostulantResult>
    {

        private readonly IPostulantRepository postulantRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostulantSignInCommandHandler(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResult> Handle(PostulantSignInCommand request, CancellationToken cancellationToken)
        {
            PostulantResult result = await Postulant.SignIn(request.FirstName, request.LastName, request.Email, request.Phone, request.Password, request.Document, postulantRepository);

            if (!result.Success)
                return result;

            try
            {
                await postulantRepository.Save(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                return new PostulantResult($"Error ocurred while saving postulant: {e.Message}");
            }

        }
    }
}