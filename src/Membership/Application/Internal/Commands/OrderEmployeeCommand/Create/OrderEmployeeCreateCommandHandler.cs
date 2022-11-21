using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Membership.Application.Internal.Commands.OrderEmployeeCommand.Create
{
    public class OrderEmployeeCreateCommandHandler : ICommandHandler<OrderEmployeeCreateCommand, OrderEmployeeResult>
    {
        private readonly IOrderEmployeeRepository orderEmployeeRepository;

        private readonly IPlanEmployeeRepository planEmployeeRepository;

        private readonly IEmployeeRepository employeeRepository;

        private readonly IUnitOfWork unitOfWork;

        public OrderEmployeeCreateCommandHandler(IOrderEmployeeRepository orderEmployeeRepository, IPlanEmployeeRepository planEmployeeRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.orderEmployeeRepository = orderEmployeeRepository;
            this.planEmployeeRepository = planEmployeeRepository;
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrderEmployeeResult> Handle(OrderEmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            OrderEmployeeResult result = await OrderEmployee.Create(request.PlanEmployeeId, request.EmployeeId, employeeRepository, planEmployeeRepository);

            if (!result.Success)
                return result;

            try
            {
                employeeRepository.Update(result.Resource.Employee);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return new OrderEmployeeResult($"Error ocurred while updating employee in order: {e.Message}");
            }

            try
            {
                await orderEmployeeRepository.Save(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                return new OrderEmployeeResult($"Error ocurred while saving order: {e.Message}");
            }
        }
    }
}