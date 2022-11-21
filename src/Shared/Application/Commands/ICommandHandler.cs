using MediatR;

namespace Jobag.src.Shared.Application.Commands
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
    }
}