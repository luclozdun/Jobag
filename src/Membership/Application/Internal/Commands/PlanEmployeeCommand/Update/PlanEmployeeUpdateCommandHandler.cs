using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Membership.Application.Internal.Commands.PlanEmployeeCommand.Update
{
    public class PlanEmployeeUpdateCommandHandler : ICommandHandler<PlanEmployeeUpdateCommand, PlanEmployeeResult>
    {
        private readonly IPlanEmployeeRepository planEmployeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlanEmployeeUpdateCommandHandler(IPlanEmployeeRepository planEmployeeRepository, IUnitOfWork unitOfWork)
        {
            this.planEmployeeRepository = planEmployeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PlanEmployeeResult> Handle(PlanEmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            PlanEmployeeId planEmployeeId = new PlanEmployeeId(request.Id);
            PlanEmployee plan = await planEmployeeRepository.FindById(planEmployeeId);

            if (plan == null)
                return new PlanEmployeeResult("Plan employee not found");

            plan.Update(request.Price, request.Name, request.Description);

            try
            {
                planEmployeeRepository.Update(plan);
                await unitOfWork.CompleteAsync();
                return new PlanEmployeeResult(plan);
            }
            catch (Exception e)
            {
                return new PlanEmployeeResult($"Error ocurred while updating plan employer: {e.Message}");
            }
        }
    }
}