using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Resume.Domain.Model.ValueObjects
{
    public class PostulantId : IdValueObject
    {
        public PostulantId(int Id) : base(Id)
        {
        }
    }
}