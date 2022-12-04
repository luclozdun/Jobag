using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.ValueObjects;

namespace Jobag.src.Resume.Domain.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> FindAll();

        Task Save(Course course);

        Task<Course> FindByName(string Name);

        Task<Course> FindById(CourseId courseId);

        void Remove(Course course);
    }
}