using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Aggregates;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Shared.Infraestructure.Resource;

namespace Jobag.src.Ability.Infraestructure.Repositories
{
    public class SkillPostulantRepository : ISkillPostulantRepository
    {
        private readonly DataBaseContext context;

        public SkillPostulantRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public void Remove(SkillPostulant skillPostulant)
        {
            context.SkillPostulants.Remove(skillPostulant);
        }

        public async Task Save(SkillPostulant skillPostulant)
        {
            await context.SkillPostulants.AddAsync(skillPostulant);
        }

        public async Task SaveList(IList<SkillPostulant> skillPostulants)
        {
            await context.SkillPostulants.AddRangeAsync(skillPostulants);
        }
    }
}