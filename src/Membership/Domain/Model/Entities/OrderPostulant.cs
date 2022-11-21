using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Membership.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Domain.Model.Entities;

namespace Jobag.src.Membership.Domain.Model.Entities
{
    public class OrderPostulant : Entity
    {
        public PlanPostulant PlanPostulant { get; private set; }

        public int PlanPostulantId { get; private set; }

        public Postulant Postulant { get; private set; }

        public int PostulantId { get; private set; }

        public double Price { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private OrderPostulant(int planEmployeeId, int employeeId, PlanPostulant planPostulant, Postulant postulant)
        {
            PlanPostulantId = planEmployeeId;
            PostulantId = employeeId;
            Price = planPostulant.Price;
            CreatedAt = DateTime.Now;
            Postulant = postulant;
            PlanPostulant = planPostulant;
        }

        public static async Task<OrderPostulantResult> Create(int _planId, int _postulantId, IPostulantRepository postulantRepository, IPlanPostulantRepository planRepository)
        {
            PostulantId postulantId = new PostulantId(_postulantId);
            PlanPostulantId planId = new PlanPostulantId(_planId);

            Postulant postulant = await postulantRepository.FindById(postulantId);
            if (postulant == null)
                return new OrderPostulantResult("Postulant not found");

            PlanPostulant plan = await planRepository.FindById(planId);
            if (plan == null)
                return new OrderPostulantResult("Plan not found");

            postulant.AddPlan(plan);

            OrderPostulant order = new OrderPostulant(_planId, _postulantId, plan, postulant);

            return new OrderPostulantResult(order);
        }
    }
}