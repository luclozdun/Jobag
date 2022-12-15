using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Application.DTOs;
using Jobag.src.Job.Domain.Model.ValueObjects.Enum;

namespace Jobag.src.Job.Application.DTOs
{
    public class JobOfferResponse
    {
        public string Title { get; }

        public string Description { get; }

        public double Salary { get; }

        public int QuantifyPostulant { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

        public Position Position { get; }

        public WorkModel WorkModel { get; }

        public bool Process { get; }

        public EmployeeResponse Employee { get; }

        public CompanyResponse Company { get; }

        public JobOfferResponse()
        {
        }
    }
}