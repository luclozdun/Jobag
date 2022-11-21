using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Domain.Model.Entities
{
    public abstract class Entity
    {
        public int Id {get; private set;}

        protected Entity()
        {
        }
    }
}