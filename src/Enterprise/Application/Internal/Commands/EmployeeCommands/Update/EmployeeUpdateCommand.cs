using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Application.DTOs;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Application.Internal.Commands.EmployeeCommands.Update
{
    public class EmployeeUpdateCommand : ICommand<EmployeeResult>
    {
        public int Id { get; }
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public Phone Phone { get; }

        public Password Password { get; }

        public Document Document { get; }

        public EmployeeUpdateCommand(int id, EmployeeRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
            Phone = request.Phone;
            Password = request.Password;
            Document = request.Document;
        }
    }
}