using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.Repository;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Ability.SkillLib.Infraestructure
{
    public class SkillRepository : ISkillRepository
    {
        DataBaseContext db;

        public SkillRepository(DataBaseContext db)
        {
            this.db = db;
        }

        public async Task CreateSkill(Skill skill)
        {
            await db.Skills.AddAsync(skill);
        }

        public async Task<Skill> FindSkillById(SkillId id)
        {
            return await db.Skills.FindAsync((int)id);
        }

        public async Task<Skill> FindSkillByName(string name)
        {
            return await db.Skills.Where(p => p.Name == name).FirstOrDefaultAsync();
        }

        public void RemoveSkill(Skill skill)
        {
            db.Skills.Remove(skill);
        }

        public void UpdateSkill(Skill skill)
        {
            db.Skills.Update(skill);
        }
    }
}