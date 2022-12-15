using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindByCompanyId
{
    public class JobOfferFindByCompanyIdCommand : ICommand<IEnumerable<JobOffer>>
    {
        public int CompanyId { get; }

        public JobOfferFindByCompanyIdCommand()
        {

        }
    }
}