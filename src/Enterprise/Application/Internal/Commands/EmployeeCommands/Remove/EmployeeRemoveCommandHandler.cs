using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Enterprise.Application.Internal.Commands.EmployeeCommands.Remove
{
    public class EmployeeRemoveCommandHandler : ICommandHandler<EmployeeRemoveCommand, EmployeeResult>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeRemoveCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResult> Handle(EmployeeRemoveCommand request, CancellationToken cancellationToken)
        {
            EmployeeId employeeId = new EmployeeId(request.Id);
            Employee employee = await employeeRepository.FindById(employeeId);
            if (employee == null)
                return new EmployeeResult("Employee not found");

            try
            {
                employeeRepository.Remove(employee);
                await unitOfWork.CompleteAsync();
                return new EmployeeResult(employee);
            }
            catch (Exception e)
            {
                return new EmployeeResult($"Error ocurred while removing employee: {e.Message}");
            }
        }
    }
}