using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Job.Infraestructure.Repository
{
    public class JobOfferPostulantRepository : IJobOfferPostulantRepository
    {
        private readonly DataBaseContext context;

        public JobOfferPostulantRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task AddJobOffer(JobOfferPostulant jobOfferPostulant)
        {
            await context.JobOfferPostulants.AddAsync(jobOfferPostulant);
        }

        public async Task<IEnumerable<JobOfferPostulant>> FindByPostulantId(PostulantId postulantId)
        {
            return await context.JobOfferPostulants.Where(x => x.PostulantId == (int)postulantId).Include(x => x.JobOffer).ToListAsync();
        }
    }
}