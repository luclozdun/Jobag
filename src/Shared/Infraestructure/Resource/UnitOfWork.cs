using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Shared.Infraestructure.Resource
{
    public class UnitOfWork : BaseRepository, IUnitOfWork
    {
        public UnitOfWork(DataBaseContext context) : base(context)
        {
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}