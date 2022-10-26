using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindPostulantById
{
    public sealed record FindPostulantByIdQuery(int Id) : IQuery<PostulantResult>;
}