using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Resume.Infraestructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataBaseContext context;

        public CourseRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Course>> FindAll()
        {
            return await context.Courses.ToListAsync();
        }

        public async Task<Course> FindById(CourseId courseId)
        {
            return await context.Courses.Where(x => x.Id == (int)courseId).FirstOrDefaultAsync();
        }

        public async Task<Course> FindByName(string Name)
        {
            return await context.Courses.Where(x => x.Name == Name).FirstOrDefaultAsync();
        }

        public void Remove(Course course)
        {
            context.Courses.Remove(course);
        }

        public async Task Save(Course course)
        {
            await context.Courses.AddAsync(course);
        }
    }
}