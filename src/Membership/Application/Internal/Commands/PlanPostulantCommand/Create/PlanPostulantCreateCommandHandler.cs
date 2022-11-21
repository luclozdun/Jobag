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

namespace Jobag.src.Membership.Application.Internal.Commands.PlanPostulantCommand.Create
{
    public class PlanPostulantCreateCommandHandler : ICommandHandler<PlanPostulantCreateCommand, PlanPostulantResult>
    {
        private readonly IPlanPostulantRepository planPostulantRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlanPostulantCreateCommandHandler(IPlanPostulantRepository planPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.planPostulantRepository = planPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PlanPostulantResult> Handle(PlanPostulantCreateCommand request, CancellationToken cancellationToken)
        {
            PlanPostulant planPostulant = PlanPostulant.Create(request.Price, request.Name, request.Description);

            try
            {
                await planPostulantRepository.Save(planPostulant);
                await unitOfWork.CompleteAsync();
                return new PlanPostulantResult(planPostulant);
            }
            catch (Exception e)
            {
                return new PlanPostulantResult($"Error ocurred while saving plan employee: {e.Message}");
            }
        }
    }
}