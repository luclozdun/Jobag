using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Enterprise.Infraestructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataBaseContext context;

        public EmployeeRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Employee>> FindByCompanyId(CompanyId CompanyId)
        {
            return await context.Employees.Where(x => x.Company.Id == (int)CompanyId).Include(x => x.Company).ToListAsync();
        }

        public async Task<Employee> FindByDocument(Document document)
        {
            return await context.Employees.Where(x => x.Document.Dni == document.Dni && x.Document.Country == document.Country).FirstOrDefaultAsync();
        }

        public async Task<Employee> FindByEmail(string Email)
        {
            return await context.Employees.Where(x => x.Email == Email).FirstOrDefaultAsync();
        }

        public async Task<Employee> FindById(EmployeeId EmployeeId)
        {
            return await context.Employees.Where(x => x.Id == (int)EmployeeId).FirstOrDefaultAsync();
        }

        public async Task<Employee> FindByPhone(Phone phone)
        {
            return await context.Employees.Where(x => x.Phone.Number == phone.Number && x.Phone.Operator == phone.Operator && x.Phone.ZipCode == phone.ZipCode).FirstOrDefaultAsync();
        }

        public void Remove(Employee employee)
        {
            context.Employees.Remove(employee);
        }

        public async Task Save(Employee employee)
        {
            await context.Employees.AddAsync(employee);
        }

        public void Update(Employee employee)
        {
            context.Employees.Update(employee);
        }
    }
}