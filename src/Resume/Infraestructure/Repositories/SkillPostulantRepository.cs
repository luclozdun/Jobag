using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Resume.Infraestructure.Repositories
{
    public class SkillPostulantRepository : ISkillPostulantRepository
    {
        private readonly DataBaseContext context;

        public SkillPostulantRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SkillPostulant>> FindByPostulantId(PostulantId postulantId)
        {
            return await context.SkillPostulants.Where(x => x.PostulantId == (int)postulantId).ToListAsync();
        }

        public async Task<SkillPostulant> FindBySkillIdAndPostulantId(SkillId skillId, PostulantId postulantId)
        {
            return await context.SkillPostulants.Where(x => (x.SkillId == (int)skillId) && (x.PostulantId == (int)postulantId)).FirstOrDefaultAsync();
        }

        public void Remove(SkillPostulant skillPostulant)
        {
            context.SkillPostulants.Remove(skillPostulant);
        }

        public void Remove(IEnumerable<SkillPostulant> skillPostulant)
        {
            context.SkillPostulants.RemoveRange(skillPostulant);
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