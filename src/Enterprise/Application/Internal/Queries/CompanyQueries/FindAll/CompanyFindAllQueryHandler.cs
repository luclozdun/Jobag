using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Queries;
using Jobag.src.Shared.Domain.Repository;
using MediatR;

namespace Jobag.src.Enterprise.Application.Internal.Queries.CompanyQueries.FindAll
{
    public class CompanyFindAllQueryHandler : IQueryHandler<CompanyFindAllQuery, IEnumerable<Company>>
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyFindAllQueryHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> Handle(CompanyFindAllQuery request, CancellationToken cancellationToken)
        {
            return await companyRepository.FindAll();
        }
    }
}