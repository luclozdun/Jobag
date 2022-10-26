using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Commands.Remove
{
    public sealed record RemovePostulantCommand(int Id) : ICommand<PostulantResult>;
}