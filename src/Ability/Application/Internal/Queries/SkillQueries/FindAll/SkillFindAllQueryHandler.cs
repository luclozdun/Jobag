using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Ability.Application.Internal.Queries.SkillQueries.FindAll
{
    public class SkillFindAllQueryHandler : IQueryHandler<SkillFindAllQuery, IEnumerable<Skill>>
    {
        private readonly ISkillRepository skillRepository;

        public SkillFindAllQueryHandler(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public async Task<IEnumerable<Skill>> Handle(SkillFindAllQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Skill> skills = await skillRepository.FindAll();
            return skills;
        }
    }
}