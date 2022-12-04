using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Application.DTOs
{
    public class EmployeeRequest
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Phone Phone { get; private set; }

        public Password Password { get; private set; }

        public Document Document { get; private set; }

        public EmployeeRequest(string firstName, string lastName, string email, Phone phone, Password password, Document document)
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