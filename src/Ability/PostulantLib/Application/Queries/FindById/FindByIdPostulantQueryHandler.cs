using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Ability.PostulantLib.Application.Queries.FindById
{
    public class FindByIdPostulantQueryHandler : QueryHandler<FindByIdPostulantQuery, PostulantResponse>
    {
        private readonly PostulantFinderById finder;

        public FindByIdPostulantQueryHandler(PostulantFinderById finder)
        {
            this.finder = finder;
        }

        public async Task<PostulantResponse> Handle(FindByIdPostulantQuery query)
        {
            PostulantResponse response = await this.finder.FindById(query);
            return response;
        }
    }
}