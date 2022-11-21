using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Ability.Infraestructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataBaseContext context;

        public SkillRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Skill>> FindAll()
        {
            return await context.Skills.ToListAsync();
        }

        public async Task<Skill> FindByName(string Name)
        {
            return await context.Skills.Where(x => x.Name == Name).FirstOrDefaultAsync();
        }

        public async Task<Skill> FindById(SkillId skillId)
        {
            return await context.Skills.Where(x => x.Id == (int)skillId).FirstOrDefaultAsync();
        }

        public void Remove(Skill skill)
        {
            context.Skills.Remove(skill);
        }

        public async Task Save(Skill skill)
        {
            await context.Skills.AddAsync(skill);
        }
    }
}