using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.ValueObject;

namespace Jobag.src.Ability.PostulantLib.Domain.ValueObject
{
    public class PostulantNumber : IntValidateValueObject
    {
        private const int MaxLength = 10;
        private const int MinLength = 0;
        public int Number { get; private set; }
        private PostulantNumber(int number) : base(number)
        {
            this.Number = number;
        }

        public static PostulantNumber Create(int number)
        {
            Validate(number, MaxLength, MinLength);
            return new PostulantNumber(number);
        }
    }
}