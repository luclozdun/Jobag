using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Jobag.src.Shared.Application.Queries
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}