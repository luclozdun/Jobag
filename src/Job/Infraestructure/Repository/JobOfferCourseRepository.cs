using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Job.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Job.Infraestructure.Repository
{
    public class JobOfferCourseRepository : IJobOfferCourseRepository
    {
        public readonly DataBaseContext context;

        public JobOfferCourseRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task Add(JobOfferCourse jobOfferCourse)
        {
            await context.JobOfferCourses.AddAsync(jobOfferCourse);
        }

        public async Task Add(IList<JobOfferCourse> jobOfferCourses)
        {
            await context.JobOfferCourses.AddRangeAsync(jobOfferCourses);
        }

        public async Task<IEnumerable<JobOfferCourse>> FindByCourseName(string name)
        {
            return await context.JobOfferCourses.Where(x => x.Course.Name == name).Include(x => x.Course).ToListAsync();
        }

        public async Task<IEnumerable<JobOfferCourse>> FindByJobOfferId(JobOfferId jobOfferId)
        {
            return await context.JobOfferCourses.Where(x => x.JobOfferId == (int)jobOfferId).ToListAsync();
        }

        public async Task<JobOfferCourse> FindByJobOfferIdAndCourseId(JobOfferId jobOfferId, CourseId courseId)
        {
            return await context.JobOfferCourses.Where(x => (x.JobOfferId == (int)jobOfferId) && (x.CourseId == (int)courseId)).FirstOrDefaultAsync();
        }

        public void Remove(JobOfferCourse jobOfferCourse)
        {
            context.JobOfferCourses.Remove(jobOfferCourse);
        }

        public void Remove(IEnumerable<JobOfferCourse> jobOfferCourses)
        {
            context.JobOfferCourses.RemoveRange(jobOfferCourses);
        }
    }
}