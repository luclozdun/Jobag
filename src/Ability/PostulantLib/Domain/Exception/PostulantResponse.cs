using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Shared.Domain.Exception;

namespace Jobag.src.Ability.PostulantLib.Domain.Exception
{
    public class PostulantResponse : BaseReponse<Postulant>
    {
        public PostulantResponse(Postulant resource) : base(resource)
        {
        }

        public PostulantResponse(string message) : base(message)
        {
        }
    }
}