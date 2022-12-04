using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Resume.Domain.Result
{
    public class CourseResult : BaseResult<Course>
    {
        public CourseResult(Course resource) : base(resource)
        {
        }

        public CourseResult(string message) : base(message)
        {
        }
    }
}