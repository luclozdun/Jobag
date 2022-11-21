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

namespace Jobag.src.Membership.Application.Internal.Commands.PlanEmployeeCommand.Remove
{
    public class PlanEmployeeUpdateCommandHandler : ICommandHandler<PlanEmployeeRemoveCommand, PlanEmployeeResult>
    {
        private readonly IPlanEmployeeRepository planEmployeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlanEmployeeUpdateCommandHandler(IPlanEmployeeRepository planEmployeeRepository, IUnitOfWork unitOfWork)
        {
            this.planEmployeeRepository = planEmployeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PlanEmployeeResult> Handle(PlanEmployeeRemoveCommand request, CancellationToken cancellationToken)
        {
            PlanEmployeeId planEmployeeId = new PlanEmployeeId(request.Id);
            PlanEmployee plan = await planEmployeeRepository.FindById(planEmployeeId);

            if (plan == null)
                return new PlanEmployeeResult("Plan employee not found");

            try
            {
                planEmployeeRepository.Update(plan);
                await unitOfWork.CompleteAsync();
                return new PlanEmployeeResult(plan);
            }
            catch (Exception e)
            {
                return new PlanEmployeeResult($"Error ocurred while removing plan employer: {e.Message}");
            }
        }
    }
}