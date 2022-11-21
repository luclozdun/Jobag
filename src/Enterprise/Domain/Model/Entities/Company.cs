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

        private Company(string name, string description, Phone phone, RUC RUC, int quantifyOfEmployees)
        {
            this.Name = name;
            this.Description = description;
            this.Phone = phone;
            this.RUC = RUC;
            this.QuantifyOfEmployees = quantifyOfEmployees;
        }

        public static async Task<CompanyResult> Create(string name, string description, Phone phone, RUC RUC, ICompanyRepository companyRepository)
        {
            Company existRuc = await companyRepository.FindByRuc(RUC);
            if (existRuc != null)
                return new CompanyResult("The ruc is being used");

            Company company = new Company(name, description, phone, RUC, 0);
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
    }
}