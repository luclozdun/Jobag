using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Model.Phone;

namespace Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Update
{
    public class CompanyUpdateCommand : ICommand<CompanyResult>
    {
        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public Phone Phone { get; }

        public CompanyUpdateCommand(int id, string name, string description, Phone phone)
        {
            Id = id;
            Name = name;
            Description = description;
            Phone = phone;
        }
    }
}