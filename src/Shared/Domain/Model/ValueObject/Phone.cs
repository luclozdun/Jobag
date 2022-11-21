using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.ValueObject.Enums;

namespace Jobag.src.Shared.Domain.Model.Phone
{
    public class Phone
    {
        public Operator Operator { get; set; }

        public int Number { get; set; }

        public ZipCode ZipCode { get; set; }

        public Phone(Operator Operator, int Number, ZipCode ZipCode)
        {
            this.Operator = Operator;
            this.Number = Number;
            this.ZipCode = ZipCode;
        }

        public static bool Validate(int Number)
        {
            int size = Number;

            if (Number < 100000000 && Number > 900000000)
            {
                throw new ArgumentException("The phone is incorrect");
            }
            return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Phone phone = (Phone)obj;
            return Number == phone.Number && ZipCode == phone.ZipCode && Operator == phone.Operator;
        }

        public static implicit operator int(Phone numberValueObject)
        {
            return numberValueObject.Number;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}