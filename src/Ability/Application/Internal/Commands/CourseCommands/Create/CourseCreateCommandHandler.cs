using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Ability.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Ability.Application.Internal.Commands.CourseCommands.Create
{
    public class CourseCreateCommandHandler : ICommandHandler<CourseCreateCommand, CourseResult>
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public CourseCreateCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CourseResult> Handle(CourseCreateCommand request, CancellationToken cancellationToken)
        {
            Course existName = await courseRepository.FindByName(request.Name.ToLower());

            if (existName != null)
                return new CourseResult("The name is being used");

            Course course = Course.Create(request.Name.ToLower(), request.Description);

            try
            {
                await courseRepository.Save(course);
                await unitOfWork.CompleteAsync();
                return new CourseResult(course);
            }
            catch (Exception e)
            {
                return new CourseResult($"Error ocurred while saving course: {e.Message}");
            }
        }
    }
}