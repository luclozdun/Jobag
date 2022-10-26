using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Ability.SkillLib.Infraestructure
{
    public class SkillPostulantRepository : ISkillPostulantRepository
    {
        DataBaseContext context;

        public SkillPostulantRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task AddSkillByIdAndPostulantById(SkillPostulant skillPostulant)
        {
            await context.SkillPostulants.AddAsync(skillPostulant);
        }

        public async Task<SkillPostulant> FindSkillPostulantBySkillIdAndPostulantId(PostulantId postulantId, SkillId skillId)
        {
            return await context.SkillPostulants.Where(x => (x.PostulantId == (int)postulantId) && (x.SkillId == (int)skillId)).FirstAsync();
        }

        public async Task<List<SkillPostulant>> FindSkillPostulantBySkillId(SkillId skillId)
        {
            return await context.SkillPostulants.Where(x => x.SkillId == (int)skillId).ToListAsync();
        }

        public void RemoveSkillPostulantBySkillId(List<SkillPostulant> skillPostulants)
        {
            context.SkillPostulants.RemoveRange(skillPostulants);
        }

        public void RemoveSkillPostulant(SkillPostulant skillPostulant)
        {
            context.SkillPostulants.Remove(skillPostulant);
        }

        public async Task AddSkillPostulantByPostulantIdAndListSkillId(IList<SkillPostulant> skillPostulants)
        {
            await context.SkillPostulants.AddRangeAsync(skillPostulants);
        }
    }
}