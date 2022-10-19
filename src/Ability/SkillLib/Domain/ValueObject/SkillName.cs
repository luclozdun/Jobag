using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.ValueObject;

namespace Jobag.src.Ability.SkillLib.Domain.ValueObject
{
    public class SkillName : StringValidateValueObject
    {
        private static int MaxLength = 40;
        private static int MinLength = 10;

        private SkillName(string Value) : base(Value)
        {
        }

        public static SkillName Create(string value)
        {
            Validate(value, MaxLength, MinLength);
            return new SkillName(value);
        }
    }
}