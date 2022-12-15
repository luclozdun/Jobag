using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindById
{
    public class JobOfferFindByIdQuery : IQuery<JobOfferResult>
    {
        public int Id { get; }

        public JobOfferFindByIdQuery(int id)
        {
            Id = id;
        }
    }
}