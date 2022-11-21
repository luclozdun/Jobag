using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.ValueObject.Enums;
using Jobag.src.Shared.Domain.ValueObject.Enums;

namespace Jobag.src.Shared.Domain.Model.ValueObject
{
    public class Document
    {
        public int Dni { get; set; }

        public Country Country { get; set; }

        public Document(int Dni, Country Country)
        {
            this.Country = Country;
            this.Dni = Dni;
        }

        public static bool Validate(int Number)
        {
            int size = Number;

            if (Number < 100000000 && Number > 900000000)
            {
                throw new ArgumentException("The first name is empty");
            }
            return true;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Document document = (Document)obj;
            return Dni == document.Dni && Country == document.Country;
        }

        public static implicit operator int(Document document)
        {
            return document.Dni;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}