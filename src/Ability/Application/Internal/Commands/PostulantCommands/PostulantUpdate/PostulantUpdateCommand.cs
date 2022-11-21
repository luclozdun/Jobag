using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Application.DTOs;
using Jobag.src.Ability.Domain.Result;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Ability.Application.Internal.Commands.PostulantCommands.PostulantUpdate
{
    public class PostulantUpdateCommand : ICommand<PostulantResult>
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public Phone Phone { get; }

        public Password Password { get; }

        public Document Document { get; }

        public PostulantUpdateCommand(int Id, PostulantRequest request)
        {
            this.Id = Id;
            this.FirstName = request.FirstName;
            this.LastName = request.LastName;
            this.Email = request.Email;
            this.Phone = request.Phone;
            this.Password = request.Password;
            this.Document = request.Document;
        }
    }
}