using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Aggregates;
using Jobag.src.Ability.Domain.Result;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Shared.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Model.Entities;
using System.Text.Json.Serialization;

namespace Jobag.src.Ability.Domain.Model.Entities
{
    public class Postulant : Entity
    {

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Phone Phone { get; private set; }

        public Password Password { get; private set; }

        public Document Document { get; private set; }

        public PlanPostulant PlanPostulant { get; private set; }

        public IList<SkillPostulant> SkillPostulants { get; set; }

        public IList<CoursePostulant> CoursePostulants { get; set; }

        [JsonIgnore]
        public IList<OrderPostulant> OrderPostulants { get; private set; }

        private Postulant(string FirstName, string LastName, string Email, Phone Phone, Password Password, Document Document)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Password = Password;
            this.Document = Document;
        }

        private Postulant() { }

        public static async Task<PostulantResult> SignIn(string FirstName, string LastName, string Email, Phone Phone, Password Password, Document Document, IPostulantRepository postulantRepository)
        {
            Postulant existDocument = await postulantRepository.FindByDocument(Document);
            if (existDocument != null)
                return new PostulantResult("The Document is being used");

            Postulant existPhone = await postulantRepository.FindByPhone(Phone);
            if (existPhone != null)
                return new PostulantResult("The Phone is being used");

            Postulant existEmail = await postulantRepository.FindByEmail(Email);
            if (existEmail != null)
                return new PostulantResult("The Email is being used");

            return new PostulantResult(new Postulant(FirstName, LastName, Email, Phone, Password, Document));
        }

        public static async Task<PostulantResult> Update(PostulantId postulantId, string FirstName, string LastName, string Email, Phone Phone, Password Password, Document Document, IPostulantRepository postulantRepository)
        {
            Postulant postulant = await postulantRepository.FindById(postulantId);

            if (postulant == null)
                return new PostulantResult("Postulant not exist");


            if (!postulant.Document.Equals(Document))
            {
                Postulant existDocument = await postulantRepository.FindByDocument(Document);
                if (existDocument != null)
                    return new PostulantResult("The Document is being used");
            }

            if (!postulant.Phone.Equals(Phone))
            {
                Postulant existPhone = await postulantRepository.FindByPhone(Phone);
                if (existPhone != null)
                    return new PostulantResult("The Phone is being used");
            }

            if (!postulant.Email.Equals(Email))
            {
                Postulant existEmail = await postulantRepository.FindByEmail(Email);
                if (existEmail != null)
                    return new PostulantResult("The Email is being used");
            }

            postulant.FirstName = FirstName;
            postulant.LastName = LastName;
            postulant.Email = Email;
            postulant.Phone = Phone;
            postulant.Password = Password;
            postulant.Document = Document;

            return new PostulantResult(postulant);
        }

        public void AddPlan(PlanPostulant planPostulant)
        {
            this.PlanPostulant = planPostulant;
        }

        public void RemovePlan()
        {
            this.PlanPostulant = null;
        }

        public void SetFirstName(string FirstName)
        {
            this.FirstName = FirstName;
        }

        public void SetLastName(string LastName)
        {
            this.LastName = LastName;
        }

        public void SetEmail(string Email)
        {
            this.Email = Email;
        }

        public void SetNumber(Phone Phone)
        {
            this.Phone = Phone;
        }

        public void SetPassword(Password Password)
        {
            this.Password = Password;
        }

        public void SetDocument(Document Document)
        {
            this.Document = Document;
        }
    }
}