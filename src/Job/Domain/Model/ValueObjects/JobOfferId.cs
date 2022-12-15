using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Job.Domain.Model.ValueObjects
{
    public class JobOfferId : IdValueObject
    {
        public JobOfferId(int Id) : base(Id)
        {
        }
    }
}