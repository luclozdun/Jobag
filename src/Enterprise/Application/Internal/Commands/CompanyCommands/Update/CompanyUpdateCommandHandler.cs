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

namespace Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Update
{
    public class CompanyUpdateCommandHandler : ICommandHandler<CompanyUpdateCommand, CompanyResult>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyUpdateCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CompanyResult> Handle(CompanyUpdateCommand request, CancellationToken cancellationToken)
        {
            CompanyResult result = await Company.Update(request.Id, request.Name, request.Description, request.Phone, companyRepository);

            if (!result.Success)
                return result;

            try
            {
                companyRepository.Update(result.Resource);
                await unitOfWork.CompleteAsync();
                return new CompanyResult(result.Resource);
            }
            catch (Exception e)
            {
                return new CompanyResult($"Error ocurred while updating company: {e.Message}");
            }


            throw new NotImplementedException();
        }
    }
}