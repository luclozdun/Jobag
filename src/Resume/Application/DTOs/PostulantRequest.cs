using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Resume.Application.DTOs
{
    public class PostulantRequest
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Phone Phone { get; private set; }

        public Password Password { get; private set; }

        public Document Document { get; private set; }

        public PostulantRequest(string FirstName, string LastName, string Email, Phone Phone, Password Password, Document Document)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Password = Password;
            this.Document = Document;
        }


    }
}