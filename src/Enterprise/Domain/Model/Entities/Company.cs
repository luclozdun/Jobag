using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Domain.Model.Entities
{
    public class Company : Aggregate
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public Phone Phone { get; private set; }

        public RUC RUC { get; private set; }

        public int QuantifyOfEmployees { get; private set; }

        public IList<Employee> Employees { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        private Company(string name, string description, Phone phone, RUC RUC, int quantifyOfEmployees, string username, string password)
        {
            this.Name = name;
            this.Description = description;
            this.Phone = phone;
            this.RUC = RUC;
            this.QuantifyOfEmployees = quantifyOfEmployees;
            Username = username;
            Password = password;
        }

        public static async Task<CompanyResult> Create(string name, string description, Phone phone, RUC RUC, string username, string password, ICompanyRepository companyRepository)
        {
            Company existRuc = await companyRepository.FindByRuc(RUC);
            if (existRuc != null)
                return new CompanyResult("The ruc is being used");

            Company company = new Company(name, description, phone, RUC, 0, username, password);
            return new CompanyResult(company);
        }

        public static async Task<CompanyResult> Update(int id, string name, string description, Phone phone, ICompanyRepository companyRepository)
        {
            CompanyId companyId = new CompanyId(id);
            Company company = await companyRepository.FindById(companyId);

            if (company == null)
                return new CompanyResult("Company not found");

            company.Name = name;
            company.Description = name;
            company.Description = description;
            company.Phone = phone;

            return new CompanyResult(company);
        }

        public static async Task<EmployeeResult> AddEmployee(string firstName, string lastName, string email, Phone phone, Password password, Document document, int companyId, IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
        {
            Company company = await companyRepository.FindById(new CompanyId(companyId));

            if (company == null)
                return new EmployeeResult("Company not found");

            Employee existDocument = await employeeRepository.FindByDocument(document);
            if (existDocument != null)
                return new EmployeeResult("The document is beign used");

            Employee existEmail = await employeeRepository.FindByEmail(email);
            if (existEmail != null)
                return new EmployeeResult("The email is beign used");

            Employee existPhone = await employeeRepository.FindByPhone(phone);
            if (existPhone != null)
                return new EmployeeResult("The phone is beign used");

            Employee employee = new Employee(firstName, lastName, email, phone, password, document, company);

            return new EmployeeResult(employee);
        }
    }
}