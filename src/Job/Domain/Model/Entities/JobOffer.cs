using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.Entities;

namespace Jobag.src.Job.Domain.Model.Entities
{
    public class JobOffer : Entity
    {
        public string Description {get; private set;}
    }
}