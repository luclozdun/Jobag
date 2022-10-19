using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.ValueObject;

namespace Jobag.src.Ability.PostulantLib.Domain.ValueObject
{
    public class PostulantDocument : StringValidateValueObject
    {
        private const int MaxLength = 50;
        private const int MinLength = 10;

        private PostulantDocument(string Value) : base(Value)
        {
        }

        public static PostulantDocument Create(string document)
        {
            Validate(document, MaxLength, MinLength);
            return new PostulantDocument(document);
        }
    }
}