using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Resume.Application.DTOs
{
    public class PostulantResponse
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Phone Phone { get; private set; }

        public Password Password { get; private set; }

        public Document Document { get; private set; }

        public IList<SkillPostulant> SkillPostulants { get; set; }
        public PostulantResponse(string firstName, string lastName, string email, Phone phone, Password password, Document document, IList<SkillPostulant> skillPostulants)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Password = password;
            Document = document;
            SkillPostulants = skillPostulants;
        }
    }
}