using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Ability.Domain.Model.ValueObjects
{
    public class CourseId : IdValueObject
    {
        public CourseId(int Id) : base(Id)
        {
        }
    }
}