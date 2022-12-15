using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Job.Infraestructure.Repository
{
    public class JobOfferRepository : IJobOfferRepository
    {
        private readonly DataBaseContext context;

        public JobOfferRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<JobOffer>> FindAll()
        {
            return await context.JobOffers.ToListAsync();
        }

        public async Task<IEnumerable<JobOffer>> FindAllIsActive()
        {
            return await context.JobOffers.Where(x => x.Process == true).ToListAsync();
        }

        public async Task<IEnumerable<JobOffer>> FindByCompanyId(CompanyId companyId)
        {
            return await context.JobOffers.Where(x => x.CompanyId == (int)companyId).ToListAsync();
        }

        public async Task<JobOffer> FindById(JobOfferId jobOfferId)
        {
            return await context.JobOffers.Where(x => x.Id == (int)jobOfferId).FirstOrDefaultAsync();
        }

        public void Remove(JobOffer jobOffer)
        {
            context.JobOffers.Remove(jobOffer);
        }

        public async Task Save(JobOffer jobOffer)
        {
            await context.JobOffers.AddAsync(jobOffer);
        }

        public void Update(JobOffer jobOffer)
        {
            context.JobOffers.Update(jobOffer);
        }
    }
}