using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Resume.Domain.Model.ValueObjects
{
    public class SkillId : IdValueObject
    {
        public SkillId(int Id) : base(Id)
        {
        }
    }
}