using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;

namespace Jobag.src.Membership.Domain.Repository
{
    public interface IOrderPostulantRepository
    {
        Task<IEnumerable<OrderPostulant>> FindAllByPostulantId(PostulantId postulantId);

        Task<IEnumerable<OrderPostulant>> FindAllByPlanId(PlanPostulantId postulantId);

        Task Save(OrderPostulant order);

        Task<OrderPostulant> FindById(OrderPostulantId orderPostulantId);
    }
}