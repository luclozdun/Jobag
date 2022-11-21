using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Remove
{
    public class CompanyRemoveCommandHandler : ICommandHandler<CompanyRemoveCommand, CompanyResult>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyRemoveCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CompanyResult> Handle(CompanyRemoveCommand request, CancellationToken cancellationToken)
        {
            CompanyId companyId = new CompanyId(request.Id);
            Company company = await companyRepository.FindById(companyId);
            if (company == null)
                return new CompanyResult("Company not found");

            try
            {
                companyRepository.Remove(company);
                await unitOfWork.CompleteAsync();
                return new CompanyResult(company);
            }
            catch (Exception e)
            {
                return new CompanyResult($"Error ocurred while removing company: {e.Message}");
            }

            throw new NotImplementedException();
        }
    }
}