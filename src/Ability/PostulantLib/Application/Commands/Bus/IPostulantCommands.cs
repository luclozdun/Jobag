using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Application.Commands.Update;
using Jobag.src.Ability.PostulantLib.Domain.Exception;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Bus
{
    public interface IPostulantCommands
    {
        Task<PostulantResponse> Create(CreatePostulantCommand command);
        Task<PostulantResponse> Update(int id, UpdatePostulantCommand command);
        Task<PostulantResponse> Remove(int id);
    }
}