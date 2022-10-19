using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Repository;

namespace Jobag.src.Ability.PostulantLib.Application.Queries.FindAll
{
    public class PostulantFinderAll
    {
        private readonly IPostulantRepository postulantRepository;

        public PostulantFinderAll(IPostulantRepository postulantRepository)
        {
            this.postulantRepository = postulantRepository;
        }

        public async Task<IEnumerable<Postulant>> FindAll()
        {
            IEnumerable<Postulant> response = await postulantRepository.FindAll();
            return response;
        }

    }
}