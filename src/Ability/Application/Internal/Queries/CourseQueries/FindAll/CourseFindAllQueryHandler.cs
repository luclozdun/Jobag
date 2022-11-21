using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Ability.Application.Internal.Queries.CourseQueries.FindAll
{
    public class CourseFindAllQueryHandler : IQueryHandler<CourseFindAllQuery, IEnumerable<Course>>
    {
        private readonly ICourseRepository courseRepository;

        public CourseFindAllQueryHandler(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> Handle(CourseFindAllQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Course> courses = await courseRepository.FindAll();
            return courses;
        }
    }
}