using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Domain.ValueObject
{
    public abstract class IntValidateValueObject
    {
        public int Value { get; private set; }

        public IntValidateValueObject(int Value)
        {
            this.Value = Value;
        }

        public static int Validate(int Value, int MaxLength, int MinLength)
        {
            if (Value > MaxLength)
            {
                throw new ArgumentException($"The value is less than {MinLength}");
            }
            else if (Value > MaxLength)
            {
                throw new ArgumentException($"The value is greater than {MinLength}");
            }
            return Value;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            IntValidateValueObject intValidateValueObject = (IntValidateValueObject)obj;
            return Value == intValidateValueObject.Value;
        }

        public static implicit operator int(IntValidateValueObject intValidateValueObject)
        {
            return intValidateValueObject.Value;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}