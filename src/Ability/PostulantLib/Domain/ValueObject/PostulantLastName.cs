using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.ValueObject;

namespace Jobag.src.Ability.PostulantLib.Domain.ValueObject
{
    public class PostulantLastName : StringValidateValueObject
    {
        public const int MaxLength = 50;
        public const int MinLength = 10;


        private PostulantLastName(string Value) : base(Value)
        {
        }

        public static PostulantLastName Create(string lastName)
        {
            Validate(lastName, MaxLength, MinLength);
            return new PostulantLastName(lastName);
        }

    }
}