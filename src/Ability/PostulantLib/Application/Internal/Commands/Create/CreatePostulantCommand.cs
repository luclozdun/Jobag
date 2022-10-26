using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Application.DTOs;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Commands
{
    public class CreatePostulantCommand : ICommand<PostulantResult>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public int Number { get; private set; }

        public string Password { get; private set; }

        public string Document { get; private set; }

        public string CivilStatus { get; private set; }

        public CreatePostulantCommand(string firstName, string lastName, string email, int number, string password, string document, string civilStatus)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Number = number;
            Password = password;
            Document = document;
            CivilStatus = civilStatus;
        }

        public CreatePostulantCommand(PostulantRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
            Number = request.Number;
            Password = request.Password;
            Document = request.Document;
            CivilStatus = request.CivilStatus;
        }
    }
}