using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Ability.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.Application.Internal.Commands.CourseCommands.Remove
{
    public class CourseRemoveCommandHandler : ICommandHandler<CourseRemoveCommand, CourseResult>
    {
        public readonly ICourseRepository courseRepository;
        public readonly IUnitOfWork unitOfWork;

        public CourseRemoveCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CourseResult> Handle(CourseRemoveCommand request, CancellationToken cancellationToken)
        {
            CourseId courseId = new CourseId(request.Id);
            Course course = await courseRepository.FindById(courseId);

            try
            {
                courseRepository.Remove(course);
                await unitOfWork.CompleteAsync();
                return new CourseResult(course);
            }
            catch (Exception e)
            {
                return new CourseResult($"Error ocurred while removing course : {e.Message}");
            }
        }
    }
}