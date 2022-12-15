using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Model.ValueObjects;

namespace Jobag.src.Job.Domain.Repository
{
    public interface IJobOfferRepository
    {
        Task<IEnumerable<JobOffer>> FindAll();

        Task<IEnumerable<JobOffer>> FindAllIsActive();

        Task<IEnumerable<JobOffer>> FindByCompanyId(CompanyId companyId);

        Task<JobOffer> FindById(JobOfferId jobOfferId);

        Task Save(JobOffer jobOffer);

        void Update(JobOffer jobOffer);

        void Remove(JobOffer jobOffer);
    }
}