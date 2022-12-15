using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Application.DTOs;
using Jobag.src.Job.Domain.Model.ValueObjects.Enum;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCommands.Save
{
    public class JobOfferSaveCommand : ICommand<JobOfferResult>
    {
        public int EmployeeId { get; }

        public int CompanyId { get; }

        public string Title { get; }

        public string Description { get; }

        public double Salary { get; }

        public int QuantifyPostulant { get; }

        public DateTime EndDate { get; }

        public Position Position { get; }

        public WorkModel WorkModel { get; }

        public JobOfferSaveCommand()
        {
        }

        public JobOfferSaveCommand(JobOfferRequest request)
        {
            EmployeeId = request.EmployeeId;
            CompanyId = request.CompanyId;
            Title = request.Title;
            Description = request.Description;
            Salary = request.Salary;
            QuantifyPostulant = request.QuantifyPostulant;
            EndDate = request.EndDate;
            Position = request.Position;
            WorkModel = request.WorkModel;
        }
    }
}