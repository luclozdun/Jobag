using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Application.DTOs;
using Jobag.src.Job.Application.Internal.Commands.JobOfferCommands.Remove;
using Jobag.src.Job.Application.Internal.Commands.JobOfferCommands.Save;
using Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindAll;
using Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindById;
using Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindIsActive;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Job.Application.Controller
{
    [Route("/joboffers")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly IMediator mediator;

        public JobOfferController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] JobOfferRequest request)
        {
            JobOfferResult result = await mediator.Send(new JobOfferSaveCommand(request));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            JobOfferResult result = await mediator.Send(new JobOfferRemove(id));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }

        [HttpGet("/active")]
        public async Task<IActionResult> FindAllIsActive()
        {
            IEnumerable<JobOffer> jobOffers = await mediator.Send(new JobOfferFindIsActiveQuery());
            return Ok(jobOffers);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            IEnumerable<JobOffer> jobOffers = await mediator.Send(new JobOfferFindAllQuery());
            return Ok(jobOffers);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> FindAll([FromRoute] int id)
        {
            JobOfferResult result = await mediator.Send(new JobOfferFindByIdQuery(id));
            return result.Success ? Ok(result.Resource) : BadRequest(result.Message);
        }
    }
}