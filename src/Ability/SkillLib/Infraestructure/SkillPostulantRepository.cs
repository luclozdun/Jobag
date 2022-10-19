using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Repository;
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

        public async Task<IList<SkillPostulant>> FindAllSkillByPostulantId(PostulantId postulantId)
        {
            var asd = await context.SkillPostulants.Include(x => x.skill).ThenInclude(x => x.skillPostulants).ToListAsync();
            return asd;
        }
    }
}