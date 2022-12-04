using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Application.DTOs
{
    public class EmployeeResponse
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public Phone Phone { get; }

        public Password Password { get; }

        public EmployeeResponse(int id, string firstName, string lastName, string email, Phone phone, Password password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}