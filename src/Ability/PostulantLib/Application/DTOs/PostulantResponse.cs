using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;

namespace Jobag.src.Ability.PostulantLib.Application.DTOs
{
    public class PostulantResponse
    {
        public PostulantResponse(Postulant postulant)
        {
            Id = postulant.Id;
            FirstName = postulant.FirstName;
            LastName = postulant.LastName;
            Email = postulant.Email;
            Number = postulant.Number;
            Password = postulant.Password;
            Document = postulant.Document;
            CivilStatus = postulant.CivilStatus;
        }

        public static PostulantResponse Convert(Postulant postulant)
        {
            return new PostulantResponse(postulant);
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public int Number { get; private set; }

        public string Password { get; private set; }

        public string Document { get; private set; }

        public string CivilStatus { get; private set; }
    }
}