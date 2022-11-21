using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Model.ValueObjects;

namespace Jobag.src.Ability.Domain.Model.Aggregates
{
    public class CoursePostulant
    {
        public int CourseId { get; private set; }
        public int PostulantId { get; private set; }

        public Course Course { get; }

        [JsonIgnore]
        public Postulant Postulant { get; }

        private CoursePostulant()
        {
        }

        public CoursePostulant(CourseId CourseId, PostulantId PostulantId)
        {
            this.CourseId = (int)CourseId;
            this.PostulantId = (int)PostulantId;
        }
    }
}