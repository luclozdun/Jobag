using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Application.Commands;
using Jobag.src.Ability.PostulantLib.Application.Commands.Bus;
using Jobag.src.Ability.PostulantLib.Application.Commands.Create;
using Jobag.src.Ability.PostulantLib.Application.Commands.Remove;
using Jobag.src.Ability.PostulantLib.Application.Commands.Update;
using Jobag.src.Ability.PostulantLib.Application.Queries.Bus;
using Jobag.src.Ability.PostulantLib.Application.Queries.FindById;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.Resource;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Ability.PostulantLib.Application.Controller
{
    [Route("/postulants")]
    [ApiController]
    public class PostulantController : ControllerBase
    {

        public readonly IPostulantQueries queries;

        public readonly IPostulantCommands commands;

        public PostulantController(IPostulantCommands commands, IPostulantQueries queries)
        {
            this.commands = commands;
            this.queries = queries;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            PostulantResponse result = await queries.FindById(id);
            return result.Success == true ? Ok(PostulantResource.Convert(result.Resource)) : BadRequest(result.Message);
        }

        [HttpGet("/info/{id}")]
        public async Task<IActionResult> FindByIdAllInfo(int id)
        {
            var a = await queries.FindInformacionById(id);
            return Ok(a);
        }

        [HttpGet]
        public async Task<IEnumerable<Postulant>> FindAll()
        {
            var result = await queries.FindAll();
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostulantCommand command)
        {
            PostulantResponse result = await commands.Create(command);
            return result.Success == true ? Ok(PostulantResource.Convert(result.Resource)) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            PostulantResponse result = await commands.Remove(id);
            return result.Success == true ? Ok(PostulantResource.Convert(result.Resource)) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePostulantCommand command)
        {
            PostulantResponse result = await commands.Update(id, command);
            return result.Success == true ? Ok(PostulantResource.Convert(result.Resource)) : BadRequest(result.Message);
        }
    }
}