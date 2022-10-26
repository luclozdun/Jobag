using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Ability.PostulantLib.Application.DTOs
{
    public sealed class PostulantRequest
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public int Number { get; }

        public string Password { get; }

        public string Document { get; }

        public string CivilStatus { get; }

        public PostulantRequest(string firstName, string lastName, string email, int number, string password, string document, string civilStatus)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Number = number;
            Password = password;
            Document = document;
            CivilStatus = civilStatus;
        }
    }
}