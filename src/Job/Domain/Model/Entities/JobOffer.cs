using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Job.Domain.Model.ValueObjects.Enum;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Model.Entities;

namespace Jobag.src.Job.Domain.Model.Entities
{
    public class JobOffer : Entity
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public double Salary { get; private set; }

        public int QuantifyPostulant { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public Position Position { get; private set; }

        public WorkModel WorkModel { get; private set; }

        public bool Process { get; private set; }

        public Employee Employee { get; private set; }

        public int EmployeeId { get; private set; }

        public Company Company { get; private set; }

        public int CompanyId { get; private set; }

        public IList<JobOfferCourse> JobOfferCourses { get; private set; }

        public IList<JobOfferPostulant> JobOfferPostulants { get; private set; }

        private JobOffer(string title, string description, double salary, DateTime endDate, Position position, WorkModel workModel, Employee employee, Company company)
        {
            Title = title;
            Description = description;
            Salary = salary;
            StartDate = DateTime.Now;
            EndDate = endDate;
            Position = position;
            WorkModel = workModel;
            Process = true;
            Employee = employee;
            Company = company;
        }

        public JobOffer()
        {
        }

        public static JobOfferResult Create(string title, string description, double salary, DateTime endDate, Position position, WorkModel workModel, Employee employee, Company company)
        {
            JobOffer jobOffer = new JobOffer(title, description, salary, endDate, position, workModel, employee, company);
            return new JobOfferResult(jobOffer);
        }

        public void CloseJobOffer()
        {
            Process = false;
        }
    }
}