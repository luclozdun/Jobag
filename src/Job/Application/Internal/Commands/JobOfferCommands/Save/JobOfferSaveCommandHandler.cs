using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCommands.Save
{
    public class JobOfferSaveCommandHandler : ICommandHandler<JobOfferSaveCommand, JobOfferResult>
    {
        private readonly IJobOfferRepository jobOfferRepository;

        private readonly IEmployeeRepository employeeRepository;

        private readonly ICompanyRepository companyRepository;

        private readonly IUnitOfWork unitOfWork;

        public JobOfferSaveCommandHandler(IJobOfferRepository jobOfferRepository, IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
        {
            this.jobOfferRepository = jobOfferRepository;
            this.unitOfWork = unitOfWork;
            this.employeeRepository = employeeRepository;
            this.companyRepository = companyRepository;
        }

        public async Task<JobOfferResult> Handle(JobOfferSaveCommand request, CancellationToken cancellationToken)
        {
            Company company = await companyRepository.FindById(new CompanyId(request.CompanyId));
            if (company == null)
                return new JobOfferResult("Company not found");


            Employee employee = await employeeRepository.FindById(new EmployeeId(request.EmployeeId));
            if (employee == null)
                return new JobOfferResult("Employee not found");

            if(!company.Id.Equals(employee.Id))
                return new JobOfferResult("Invalid credentials of employee");

            JobOfferResult result = JobOffer.Create(request.Title, request.Description, request.Salary, request.EndDate, request.Position,request.WorkModel,employee, company);

            try{
                await jobOfferRepository.Save(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }catch(Exception e){
                return new JobOfferResult($"Error ocurred while saving job offer: {e.Message}");
            }

        }
    }
}