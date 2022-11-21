using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Domain.Repository
{
    public interface IEmployeeRepository
    {
        Task Save(Employee employee);

        void Remove(Employee employee);

        void Update(Employee employee);

        Task<Employee> FindById(EmployeeId EmployeeId);

        Task<Employee> FindByEmail(string Email);

        Task<Employee> FindByDocument(Document Document);

        Task<Employee> FindByPhone(Phone Phone);

        Task<IEnumerable<Employee>> FindByCompanyId(CompanyId CompanyId);
    }
}