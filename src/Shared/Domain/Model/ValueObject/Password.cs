using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Domain.Model.ValueObject
{
    public class Password
    {
        public string Value { get; private set; }

        public Password(string Value)
        {
            this.Value = Value;
        }

        public static string Validate(string Value, int MinLength)
        {

            int size = Value.Length;

            if (string.IsNullOrEmpty(Value))
            {
                throw new ArgumentException("The first name is empty");
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

            Password password = (Password)obj;
            return Value == password.Value;
        }

        public static implicit operator string(Password password)
        {
            return password.Value;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}