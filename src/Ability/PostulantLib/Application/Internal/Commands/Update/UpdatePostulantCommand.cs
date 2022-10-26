using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Application.DTOs;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Commands.Update
{
    public sealed record UpdatePostulantCommand : ICommand<PostulantResult>
    {

        public int Id { get; }
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public int Number { get; }

        public string Password { get; }

        public string Document { get; }

        public string CivilStatus { get; }

        public UpdatePostulantCommand(int id, string firstName, string lastName, string email, int number, string password, string document, string civilStatus)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Number = number;
            Password = password;
            Document = document;
            CivilStatus = civilStatus;
        }

        public UpdatePostulantCommand(int id, PostulantRequest request)
        {
            Id = id;
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