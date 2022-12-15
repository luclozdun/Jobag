using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Domain.Model.Aggregates
{
    public class Employee : Entity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Phone Phone { get; private set; }

        public Password Password { get; private set; }

        public Document Document { get; private set; }

        public Company Company { get; private set; }

        [JsonIgnore]
        public IList<JobOffer> JobOffers { get; private set; }

        internal Employee(string firstName, string lastName, string email, Phone phone, Password password, Document document, Company company)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Password = password;
            Document = document;
            Company = company;
        }

        private Employee()
        {
        }

        public static async Task<EmployeeResult> Update(int id, string firstName, string lastName, string email, Phone phone, Password password, Document document, IEmployeeRepository employeeRepository)
        {
            EmployeeId employeeId = new EmployeeId(id);
            Employee employee = await employeeRepository.FindById(employeeId);
            if (employee == null)
                return new EmployeeResult("Employee not found");

            if (!employee.Document.Equals(document))
            {
                Employee existDocument = await employeeRepository.FindByDocument(document);

                if (existDocument != null)
                    return new EmployeeResult("The document is beign used");
            }

            if (!employee.Email.Equals(email))
            {
                Employee existEmail = await employeeRepository.FindByEmail(email);

                if (existEmail != null)
                    return new EmployeeResult("The email is beign used");
            }
            if (!employee.Phone.Equals(phone))
            {
                Employee existPhone = await employeeRepository.FindByPhone(phone);

                if (existPhone != null)
                    return new EmployeeResult("The phone is beign used");

            }

            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Email = email;
            employee.Phone = phone;
            employee.Password = password;
            employee.Document = document;

            return new EmployeeResult(employee);
        }
    }
}