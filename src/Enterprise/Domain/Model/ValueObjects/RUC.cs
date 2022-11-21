using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects.Enums;
using Jobag.src.Shared.Domain.Model.ValueObject.Enums;

namespace Jobag.src.Enterprise.Domain.Model.ValueObjects
{
    public class RUC
    {
        public int CodeRuc { get; private set; }
        public Country Country { get; private set; }
        public DateTime Inscription { get; private set; }
        public string Address { get; private set; }
        public TypeTaxPayer TypeTaxPayer { get; private set; }

        public RUC(int codeRuc, Country country, DateTime inscription, string address, TypeTaxPayer typeTaxPayer)
        {
            CodeRuc = codeRuc;
            Country = country;
            Inscription = inscription;
            Address = address;
            TypeTaxPayer = typeTaxPayer;
        }
    }
}