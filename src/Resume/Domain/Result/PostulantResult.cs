using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Resume.Domain.Result
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