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

namespace Jobag.src.Enterprise.Application.Internal.Commands.EmployeeCommands.Create
{
    public class EmployeeCreateCommandHandler : ICommandHandler<EmployeeCreateCommand, EmployeeResult>
    {
        private readonly IEmployeeRepository employeeRepository;

        private readonly IUnitOfWork unitOfWork;

        public EmployeeCreateCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResult> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            EmployeeResult result = await Employee.Create(request.FirstName, request.LastName, request.Email, request.Phone, request.Password, request.Document, employeeRepository);

            if (!result.Success)
                return result;

            try
            {
                await employeeRepository.Save(result.Resource);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception e)
            {
                return new EmployeeResult($"Error ocurred while removing employee: {e.Message}");
            }
        }
    }
}