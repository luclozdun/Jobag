using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Resume.Domain.Model.ValueObjects;

namespace Jobag.src.Job.Domain.Repository
{
    public interface IJobOfferPostulantRepository
    {
        Task<IEnumerable<JobOfferPostulant>> FindByPostulantId(PostulantId postulantId);

        Task AddJobOffer(JobOfferPostulant jobOfferPostulant);
    }
}