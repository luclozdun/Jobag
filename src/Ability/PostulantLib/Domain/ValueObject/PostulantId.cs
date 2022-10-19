using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Ability.PostulantLib.Domain.ValueObject
{
    public class PostulantId
    {
        public int Id { get; private set; }


        public PostulantId(int id)
        {
            Id = id;
        }

        public static PostulantId Create(int id)
        {
            return new PostulantId(id);
        }

        public bool IsEquals(object obj)
        {
            if (obj == null)
                return false;

            PostulantId valueObject = (PostulantId)obj;

            return Id == valueObject.Id;
        }

        public static implicit operator int(PostulantId postulantId)
        {
            return postulantId.Id;
        }
    }
}