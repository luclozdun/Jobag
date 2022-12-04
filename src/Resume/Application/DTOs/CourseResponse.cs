using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;

namespace Jobag.src.Resume.Application.DTOs
{
    public class CourseResponse
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }

        public CourseResponse(Course course)
        {
            this.Id = course.Id;
            this.Name = course.Name;
            this.Description = course.Description;
        }
    }
}