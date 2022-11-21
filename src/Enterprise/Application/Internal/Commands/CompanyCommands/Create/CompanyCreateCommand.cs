using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Model.Phone;

namespace Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Create
{
    public class CompanyCreateCommand : ICommand<CompanyResult>
    {
        public string Name { get; }

        public string Description { get; }

        public Phone Phone { get; }

        public RUC RUC { get; }

        public int QuantifyOfEmployees { get; }

        public CompanyCreateCommand(string name, string description, Phone phone, RUC rUC, int quantifyOfEmployees)
        {
            Name = name;
            Description = description;
            Phone = phone;
            RUC = rUC;
            QuantifyOfEmployees = quantifyOfEmployees;
        }
    }
}