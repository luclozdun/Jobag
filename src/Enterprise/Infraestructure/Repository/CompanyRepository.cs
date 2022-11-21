using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Enterprise.Infraestructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public readonly DataBaseContext context;

        public CompanyRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Company>> FindAll()
        {
            return await context.Companies.ToListAsync();
        }

        public async Task<Company> FindById(CompanyId companyId)
        {
            return await context.Companies.Where(x => x.Id == (int)companyId).FirstOrDefaultAsync();
        }

        public async Task<Company> FindByRuc(RUC ruc)
        {
            return await context.Companies.Where(x => x.RUC.CodeRuc == ruc.CodeRuc && x.RUC.Country == ruc.Country && x.RUC.TypeTaxPayer == ruc.TypeTaxPayer).FirstOrDefaultAsync();
        }

        public void Remove(Company company)
        {
            context.Companies.Remove(company);
        }

        public async Task Save(Company company)
        {
            await context.Companies.AddAsync(company);
        }

        public void Update(Company company)
        {
            context.Companies.Update(company);
        }
    }
}