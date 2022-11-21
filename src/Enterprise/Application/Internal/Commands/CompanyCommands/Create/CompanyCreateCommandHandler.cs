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

namespace Jobag.src.Enterprise.Application.Internal.Commands.CompanyCommands.Create
{
    public class CompanyCreateCommandHandler : ICommandHandler<CompanyCreateCommand, CompanyResult>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyCreateCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CompanyResult> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
        {
            CompanyResult result = await Company.Create(request.Name, request.Description, request.Phone, request.RUC, companyRepository);

            if (!result.Success)
                return result;

            try
            {
                await companyRepository.Save(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                return new CompanyResult($"Error ocurred while saving company: {e.Message}");
            }

        }
    }
}