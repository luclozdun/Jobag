using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.ValueObject;

namespace Jobag.src.Ability.PostulantLib.Domain.ValueObject
{
    public class PostulantPassword : StringValidateValueObject
    {
        private const int MaxLength = 50;
        private const int MinLength = 10;

        private PostulantPassword(string Value) : base(Value)
        {
        }
        public static PostulantPassword Create(string password)
        {
            Validate(password, MaxLength, MinLength);
            EncryptPassword(password);
            return new PostulantPassword(password);
        }

        public static bool EncodePassword(string password)
        {
            return false;
        }

        private static string EncryptPassword(string password)
        {
            return password;
        }
    }
}