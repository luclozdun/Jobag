using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Membership.Application.Internal.Commands.OrderPostulantCommand.Create
{
    public class OrderPostulantCreateCommandHandler : ICommandHandler<OrderPostulantCreateCommand, OrderPostulantResult>
    {
        private readonly IOrderPostulantRepository orderPostulantRepository;

        private readonly IPlanPostulantRepository planPostulantRepository;

        private readonly IPostulantRepository postulantRepository;

        private readonly IUnitOfWork unitOfWork;

        public OrderPostulantCreateCommandHandler(IOrderPostulantRepository orderPostulantRepository, IPlanPostulantRepository planPostulantRepository, IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            this.orderPostulantRepository = orderPostulantRepository;
            this.planPostulantRepository = planPostulantRepository;
            this.postulantRepository = postulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrderPostulantResult> Handle(OrderPostulantCreateCommand request, CancellationToken cancellationToken)
        {
            OrderPostulantResult result = await OrderPostulant.Create(request.PlanPostulantId, request.PostulantId, postulantRepository, planPostulantRepository);

            if (!result.Success)
                return result;

            try
            {
                postulantRepository.Update(result.Resource.Postulant);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return new OrderPostulantResult($"Error ocurred while updating employee in order: {e.Message}");
            }

            try
            {
                await orderPostulantRepository.Save(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                return new OrderPostulantResult($"Error ocurred while saving order: {e.Message}");
            }
        }
    }
}