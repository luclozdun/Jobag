using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.ValueObject;

namespace Jobag.src.Ability.PostulantLib.Domain.ValueObject
{
    public class PostulantEmail : StringValidateValueObject
    {
        private const int MaxLength = 50;
        private const int MinLength = 10;

        private PostulantEmail(string Value) : base(Value)
        {
        }

        public static PostulantEmail Create(string email)
        {
            Validate(email, MaxLength, MinLength);
            return new PostulantEmail(email);
        }
    }
}