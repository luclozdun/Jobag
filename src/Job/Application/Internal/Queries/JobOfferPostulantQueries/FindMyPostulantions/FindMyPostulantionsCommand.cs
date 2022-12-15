using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Queries.JobOfferPostulantQueries.FindMyPostulantions
{
    public class FindMyPostulantionsCommand : ICommand<IEnumerable<JobOfferPostulant>>
    {
        public int PostulantId { get; }

        public FindMyPostulantionsCommand()
        {

        }
    }
}