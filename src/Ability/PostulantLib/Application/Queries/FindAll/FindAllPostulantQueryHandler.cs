using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Ability.PostulantLib.Application.Queries.FindAll
{
    public class FindAllPostulantQueryHandler
    {
        private readonly PostulantFinderAll finder;

        public FindAllPostulantQueryHandler(PostulantFinderAll finder)
        {
            this.finder = finder;
        }

        public async Task<IEnumerable<Postulant>> Handle()
        {
            return await finder.FindAll();
        }
    }
}