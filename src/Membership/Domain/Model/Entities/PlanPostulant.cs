using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Model.Entities;

namespace Jobag.src.Membership.Domain.Model.Entities
{
    public class PlanPostulant : Entity
    {
        public double Price { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        [JsonIgnore]
        public List<Postulant> Postulants { get; private set; }

        [JsonIgnore]
        public List<OrderPostulant> OrderPostulants { get; private set; }

        private PlanPostulant(double price, string name, string description)
        {
            Price = price;
            Name = name;
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public static PlanPostulant Create(double price, string name, string description)
        {
            PlanPostulant planPostulant = new PlanPostulant(price, name, description);
            return planPostulant;
        }

        public void Update(double price, string name, string description, string updatedName)
        {
            Price = price;
            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now;
        }
    }
}