using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Membership.Application.Internal.Commands.PlanEmployeeCommand.Create
{
    public class PlanEmployeeCreateCommandHandler : ICommandHandler<PlanEmployeeCreateCommand, PlanEmployeeResult>
    {
        private readonly IPlanEmployeeRepository planEmployeeRepository;

        private readonly IUnitOfWork unitOfWork;

        public PlanEmployeeCreateCommandHandler(IPlanEmployeeRepository planEmployeeRepository, IUnitOfWork unitOfWork)
        {
            this.planEmployeeRepository = planEmployeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PlanEmployeeResult> Handle(PlanEmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            PlanEmployee plan = PlanEmployee.Create(request.Price, request.Name, request.Description);

            try
            {
                await planEmployeeRepository.Save(plan);
                await unitOfWork.CompleteAsync();
                return new PlanEmployeeResult(plan);
            }
            catch (Exception e)
            {
                return new PlanEmployeeResult($"Error ocurred while saving plan employee: {e.Message}");
            }
        }
    }
}