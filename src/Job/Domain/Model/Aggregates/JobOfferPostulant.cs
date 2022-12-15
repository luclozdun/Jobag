using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.ValueObjects;

namespace Jobag.src.Job.Domain.Model.Aggregates
{
    public class JobOfferPostulant
    {
        public int PostulantId { get; private set; }
        public int JobOfferId { get; private set; }
        public Postulant Postulant { get; private set; }
        public JobOffer JobOffer { get; private set; }
        public bool State { get; private set; }
        public string Message { get; private set; }

        private JobOfferPostulant()
        {
        }

        private JobOfferPostulant(PostulantId postulantId, JobOfferId jobOfferId)
        {
            PostulantId = postulantId;
            JobOfferId = jobOfferId;
            State = false;
            Message = "Wait the asnwer";
        }

        public static JobOfferPostulant ApplyJobOffer(PostulantId postulantId, JobOfferId jobOfferId)
        {
            return new JobOfferPostulant(postulantId, jobOfferId);
        }
    }
}