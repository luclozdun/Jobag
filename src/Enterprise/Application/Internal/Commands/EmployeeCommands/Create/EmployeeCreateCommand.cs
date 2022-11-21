using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Application.Internal.Commands.EmployeeCommands.Create
{
    public class EmployeeCreateCommand : ICommand<EmployeeResult>
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public Phone Phone { get; }

        public Password Password { get; }

        public Document Document { get; }

        public EmployeeCreateCommand(string firstName, string lastName, string email, Phone phone, Password password, Document document)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Password = password;
            Document = document;
        }
    }
}