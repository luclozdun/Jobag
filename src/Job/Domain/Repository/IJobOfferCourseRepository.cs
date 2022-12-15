using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Job.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Model.ValueObjects;

namespace Jobag.src.Job.Domain.Repository
{
    public interface IJobOfferCourseRepository
    {
        Task<IEnumerable<JobOfferCourse>> FindByCourseName(string name);

        Task Add(JobOfferCourse jobOfferCourse);

        Task Add(IList<JobOfferCourse> jobOfferCourses);

        void Remove(JobOfferCourse jobOfferCourse);

        void Remove(IEnumerable<JobOfferCourse> jobOfferCourses);

        Task<JobOfferCourse> FindByJobOfferIdAndCourseId(JobOfferId jobOfferId, CourseId courseId);

        Task<IEnumerable<JobOfferCourse>> FindByJobOfferId(JobOfferId jobOfferId);
    }
}