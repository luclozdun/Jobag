using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.PostulantLib.Application.Commands.Update
{
    public class UpdatePostulantCommand : Command
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public int Number { get; private set; }

        public string Password { get; private set; }

        public string Document { get; private set; }

        public string CivilStatus { get; private set; }

        public UpdatePostulantCommand(string firstName, string lastName, string email, int number, string password, string document, string civilStatus)
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