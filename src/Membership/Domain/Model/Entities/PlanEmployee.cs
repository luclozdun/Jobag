using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Domain.Model.Entities;

namespace Jobag.src.Membership.Domain.Model.Entities
{
    public class PlanEmployee : Entity
    {
        public double Price { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        [JsonIgnore]
        public IList<Employee> Employees { get; private set; }

        [JsonIgnore]
        public IList<OrderEmployee> OrderEmployees { get; private set; }

        private PlanEmployee(double price, string name, string description)
        {
            Price = price;
            Name = name;
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public static PlanEmployee Create(double price, string name, string description)
        {
            PlanEmployee planEmployee = new PlanEmployee(price, name, description);
            return planEmployee;
        }

        public void Update(double price, string name, string description)
        {
            Price = price;
            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now;
        }
    }
}