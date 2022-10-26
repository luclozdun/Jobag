using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;

namespace Jobag.src.Ability.PostulantLib.Domain.Entity
{
    public class Postulant
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public PostulantEmail Email { get; private set; }

        public PostulantNumber Number { get; private set; }

        public PostulantPassword Password { get; private set; }

        public PostulantDocument Document { get; private set; }

        public string CivilStatus { get; private set; }

        public IList<SkillPostulant> SkillPostulants { get; set; }
        private Postulant(int id, string firstName, string lastName, PostulantEmail email, PostulantNumber number, PostulantPassword password, PostulantDocument document, string civilStatus)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Number = number;
            this.Password = password;
            this.Document = document;
            this.CivilStatus = civilStatus;
        }

        private Postulant()
        {
        }

        public void Update(Postulant request)
        {
            this.FirstName = request.FirstName;
            this.LastName = request.LastName;
            this.Email = request.Email;
            this.Number = request.Number;
            this.Password = request.Password;
            this.Document = request.Document;
            this.CivilStatus = request.CivilStatus;
        }

        public static Postulant Create(string firstName, string lastName, PostulantEmail email, PostulantNumber number, PostulantPassword password, PostulantDocument document, string civilStatus)
        {
            return new Postulant(0, firstName, lastName, email, number, password, document, civilStatus);
        }

        public void setId(PostulantId id)
        {
            this.Id = (int)id;
        }

        public void SetFirstName(string FirstName)
        {
            this.FirstName = FirstName;
        }

        public void SetLastName(string LastName)
        {
            this.LastName = LastName;
        }

        public void SetEmail(PostulantEmail Email)
        {
            this.Email = Email;
        }

        public void SetNumber(PostulantNumber Number)
        {
            this.Number = Number;
        }

        public void SetPassword(PostulantPassword Password)
        {
            this.Password = Password;
        }

        public void SetDocument(PostulantDocument Document)
        {
            this.Document = Document;
        }

        public void SetCivilStatus(string CivilStatus)
        {
            this.CivilStatus = CivilStatus;
        }
    }
}