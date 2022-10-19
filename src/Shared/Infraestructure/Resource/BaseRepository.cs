using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Infraestructure.Resource
{
    public abstract class BaseRepository
    {
        protected readonly DataBaseContext context;
        protected BaseRepository(DataBaseContext context)
        {
            this.context = context;
        }
    }
}