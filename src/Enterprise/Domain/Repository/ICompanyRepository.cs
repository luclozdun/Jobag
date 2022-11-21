using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;

namespace Jobag.src.Enterprise.Domain.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> FindAll();

        Task Save(Company company);

        void Update(Company company);

        void Remove(Company company);

        Task<Company> FindById(CompanyId companyId);

        Task<Company> FindByRuc(RUC ruc);
    }
}