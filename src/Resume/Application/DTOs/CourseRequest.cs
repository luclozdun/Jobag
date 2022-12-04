using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Resume.Application.DTOs
{
    public class CourseRequest
    {
        public string Name { get; }
        public string Description { get; }

        public CourseRequest(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}