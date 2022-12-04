using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Shared.Domain.Model.Phone;

namespace Jobag.src.Enterprise.Application.DTOs
{
    public class CompanyRequest
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public Phone Phone { get; private set; }

        public RUC RUC { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public CompanyRequest(string name, string description, Phone phone, RUC rUC, string username, string password)
        {
            Name = name;
            Description = description;
            Phone = phone;
            RUC = rUC;
            Username = username;
            Password = password;
        }
    }
}