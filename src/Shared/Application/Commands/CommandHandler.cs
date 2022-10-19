using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Application.Commands
{
    public interface CommandHandler<TCommand, TResponse> where TCommand : Command
    {
        Task<TResponse> Handle(TCommand command);
    }

    public interface UCommandHandler<TCommand, TResponse> where TCommand : Command
    {
        Task<TResponse> Handle(int id, TCommand command);
    }
}