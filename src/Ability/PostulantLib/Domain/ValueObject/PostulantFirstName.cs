using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.ValueObject;

namespace Jobag.src.Ability.PostulantLib.Domain.ValueObject
{
    public class PostulantFirstName : StringValidateValueObject
    {
        public const int MaxLength = 50;
        public const int MinLength = 10;


        private PostulantFirstName(string Value) : base(Value)
        {
        }

        public static PostulantFirstName Create(string firstName)
        {
            Validate(firstName, MaxLength, MinLength);
            return new PostulantFirstName(firstName);
        }
    }
}