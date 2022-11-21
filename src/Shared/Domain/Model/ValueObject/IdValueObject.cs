using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Domain.Model.ValueObject
{
    public class IdValueObject
    {
        public int Id { get; private set; }

        public IdValueObject(int Id)
        {
            this.Id = Id;
        }

        public static int Validate(int Id)
        {
            return Id;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            IdValueObject intValidateValueObject = (IdValueObject)obj;
            return Id == intValidateValueObject.Id;
        }

        public static implicit operator int(IdValueObject idValueObject)
        {
            return idValueObject.Id;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}