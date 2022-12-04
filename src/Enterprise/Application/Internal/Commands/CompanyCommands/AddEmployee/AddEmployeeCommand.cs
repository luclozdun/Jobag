using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Application.DTOs;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.AddEmployee
{
    public class AddEmployeeCommand : ICommand<EmployeeResult>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Phone Phone { get; private set; }

        public Password Password { get; private set; }

        public Document Document { get; private set; }

        public int CompanyId { get; private set; }

        public AddEmployeeCommand(EmployeeRequest request, int companyId)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
            Phone = request.Phone;
            Password = request.Password;
            Document = request.Document;
            CompanyId = companyId;
        }
    }
}