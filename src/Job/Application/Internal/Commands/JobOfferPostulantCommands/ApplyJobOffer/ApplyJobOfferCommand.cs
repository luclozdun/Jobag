using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferPostulantCommands.ApplyJobOffer
{
    public class ApplyJobOfferCommand : ICommand<JobOfferPostulantResult>
    {
        public int JobOfferId { get; }
        public int PostulantId { get; }

        public ApplyJobOfferCommand()
        {
        }
    }
}