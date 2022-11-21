using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Enterprise.Application.Internal.Commands.EmployeeCommands.Update
{
    public class EmployeeUpdateCommandHandler : ICommandHandler<EmployeeUpdateCommand, EmployeeResult>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeUpdateCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResult> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            EmployeeResult result = await Employee.Update(request.Id, request.FirstName, request.LastName, request.Email, request.Phone, request.Password, request.Document, employeeRepository);

            if (!result.Success)
                return result;

            try
            {
                employeeRepository.Update(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                return new EmployeeResult($"Error ocurred while updating employee: {e.Message}");
            }
        }
    }
}