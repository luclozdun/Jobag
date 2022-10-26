using MediatR;

namespace Jobag.src.Shared.Application.Commands
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}