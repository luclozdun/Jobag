using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;

namespace Jobag.src.Membership.Domain.Repository
{
    public interface IPlanPostulantRepository
    {
        Task<IEnumerable<PlanPostulant>> FindAll();

        Task<PlanPostulant> FindById(PlanPostulantId planPostulantId);

        Task Save(PlanPostulant planPostulant);

        void Update(PlanPostulant planPostulant);

        void Remove(PlanPostulant planPostulant);
    }
}