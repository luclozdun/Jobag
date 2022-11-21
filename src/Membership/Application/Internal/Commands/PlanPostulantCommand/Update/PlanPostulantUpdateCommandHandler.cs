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

namespace Jobag.src.Membership.Application.Internal.Commands.PlanPostulantCommand.Update
{
    public class PlanPostulantUpdateCommandHandler : ICommandHandler<PlanPostulantUpdateCommand, PlanPostulantResult>
    {
        private readonly IPlanPostulantRepository planPostulantRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlanPostulantUpdateCommandHandler(IPlanPostulantRepository planPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.planPostulantRepository = planPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PlanPostulantResult> Handle(PlanPostulantUpdateCommand request, CancellationToken cancellationToken)
        {
            PlanPostulantId planPostulantId = new PlanPostulantId(request.Id);
            PlanPostulant planPostulant = await planPostulantRepository.FindById(planPostulantId);

            if (planPostulant == null)
            {
                return new PlanPostulantResult("Plan postulant not found");
            }

            try
            {
                planPostulantRepository.Update(planPostulant);
                await unitOfWork.CompleteAsync();
                return new PlanPostulantResult(planPostulant);
            }
            catch (Exception e)
            {
                return new PlanPostulantResult($"Error ocurred while updating plan employee: {e.Message}");
            }
        }
    }
}