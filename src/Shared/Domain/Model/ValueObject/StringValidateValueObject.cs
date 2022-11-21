using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Domain.Model.ValueObject
{
    public abstract class StringValidateValueObject
    {
        public string Value { get; private set; }

        public StringValidateValueObject(string Value)
        {
            this.Value = Value;
        }

        public static string Validate(string Value, int MaxLength, int MinLength)
        {

            int size = Value.Length;

            if (string.IsNullOrEmpty(Value))
            {
                throw new ArgumentException("The first name is empty");
            }
            else if (size > MaxLength)
            {
                throw new ArgumentException($"The caracters is greater than {MaxLength}");
            }
            else if (size < MinLength)
            {
                throw new ArgumentException($"The caracters is less than {MinLength}");
            }
            return Value;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            StringValidateValueObject stringValidateValueObject = (StringValidateValueObject)obj;
            return Value == stringValidateValueObject.Value;
        }

        public static implicit operator string(StringValidateValueObject stringValidateValueObject)
        {
            return stringValidateValueObject.Value;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}