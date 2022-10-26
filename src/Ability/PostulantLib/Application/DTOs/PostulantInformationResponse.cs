using System.Collections.Generic;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Application.DTOs;

namespace Jobag.src.Ability.PostulantLib.Application.DTOs
{
    public class PostulantInformationResponse
    {
        public PostulantInformationResponse(Postulant postulant)
        {
            Id = postulant.Id;
            FirstName = postulant.FirstName;
            LastName = postulant.LastName;
            Email = postulant.Email;
            Number = postulant.Number;
            Password = postulant.Password;
            Document = postulant.Document;
            CivilStatus = postulant.CivilStatus;
            Skills = SkillResponse.ConvertToList(postulant.SkillPostulants);
        }

        public static PostulantInformationResponse Convert(Postulant postulant)
        {
            return new PostulantInformationResponse(postulant);
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public int Number { get; private set; }

        public string Password { get; private set; }

        public string Document { get; private set; }

        public string CivilStatus { get; private set; }

        public IList<SkillResponse> Skills { get; private set; }
    }
}