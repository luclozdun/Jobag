using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Ability.Domain.Result
{
    public class PostulantResult : BaseResult<Postulant>
    {
        public PostulantResult(Postulant resource) : base(resource)
        {
        }

        public PostulantResult(string message) : base(message)
        {
        }
    }
}