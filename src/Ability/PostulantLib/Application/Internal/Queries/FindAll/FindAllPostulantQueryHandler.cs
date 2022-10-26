using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindAll
{
    internal sealed class FindAllPostulantQueryHandler : IQueryHandler<FindAllPostulantQuery, IEnumerable<Postulant>>
    {
        private readonly IPostulantRepository postulantRepository;

        public FindAllPostulantQueryHandler(IPostulantRepository postulantRepository)
        {
            this.postulantRepository = postulantRepository;
        }

        public async Task<IEnumerable<Postulant>> Handle(FindAllPostulantQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Postulant> response = await postulantRepository.FindAll();
            return response;
        }
    }
}