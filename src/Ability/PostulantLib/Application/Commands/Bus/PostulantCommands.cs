using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Application.Commands.Create;
using Jobag.src.Ability.PostulantLib.Application.Commands.Remove;
using Jobag.src.Ability.PostulantLib.Application.Commands.Update;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Bus
{
    public class PostulantCommands : IPostulantCommands
    {
        private readonly IPostulantRepository postulantRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostulantCommands(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostulantResponse> Create(CreatePostulantCommand command)
        {
            CreatePostulantCommandHandler handler = new CreatePostulantCommandHandler(new PostulantCreator(postulantRepository, unitOfWork));
            return await handler.Handle(command);
        }

        public async Task<PostulantResponse> Remove(int id)
        {
            RemovePostulantCommand command = new RemovePostulantCommand(id);
            RemovePostulantCommandHandler handler = new RemovePostulantCommandHandler(new PostulantRemover(postulantRepository, unitOfWork));
            return await handler.Handle(command);
        }

        public async Task<PostulantResponse> Update(int id, UpdatePostulantCommand command)
        {
            UpdatePostulantCommandHandler handler = new UpdatePostulantCommandHandler(new PostulantUpdater(postulantRepository, unitOfWork));
            return await handler.Handle(id, command);
        }
    }
}