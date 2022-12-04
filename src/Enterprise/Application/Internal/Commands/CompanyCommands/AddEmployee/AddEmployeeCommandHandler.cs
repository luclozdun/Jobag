using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.AddEmployee
{
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeCommand, EmployeeResult>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResult> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeResult result = await Company.AddEmployee(request.FirstName, request.LastName, request.Email, request.Phone, request.Password, request.Document, request.CompanyId, employeeRepository, companyRepository);

            if (!result.Success)
                return result;

            try
            {
                await employeeRepository.Save(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                return new EmployeeResult($"Error ocurred while saving employee: {e.Message}");
            }
        }
    }
}