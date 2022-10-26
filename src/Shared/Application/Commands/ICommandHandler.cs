using MediatR;

namespace Jobag.src.Shared.Application.Commands
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
    {
    }
}