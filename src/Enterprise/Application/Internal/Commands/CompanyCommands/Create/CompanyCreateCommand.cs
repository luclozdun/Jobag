using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Application.DTOs;
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

        public string Username {get;}

        public string Password {get;}

        public CompanyCreateCommand(CompanyRequest request)
        {
            Name = request.Name;
            Description = request.Description;
            Phone = request.Phone;
            RUC = request.RUC;
            QuantifyOfEmployees = 0;
            Username = request.Username;
            Password = request.Password;
        }
    }
}