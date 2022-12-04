using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Shared.Domain.Model.Phone;

namespace Jobag.src.Enterprise.Application.DTOs
{
    public class CompanyResponse
    {
        public int Id { get; }
        public string Name { get; }

        public string Description { get; }

        public Phone Phone { get; }

        public RUC RUC { get; }

        public CompanyResponse(int id, string name, string description, Phone phone, RUC rUC)
        {
            Id = id;
            Name = name;
            Description = description;
            Phone = phone;
            RUC = rUC;
        }
    }
}