using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Remove
{
    public class CompanyRemoveCommand : ICommand<CompanyResult>
    {
        public int Id { get; }

        public CompanyRemoveCommand(int id)
        {
            Id = id;
        }
    }
}