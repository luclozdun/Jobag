using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCommands.Remove
{
    public class JobOfferRemove : ICommand<JobOfferResult>
    {
        public JobOfferRemove()
        {
        }

        public int JobOfferId { get; }

        public JobOfferRemove(int jobOfferId)
        {
            JobOfferId = jobOfferId;
        }
    }
}