using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Ability.Domain.Repositories;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Ability.Infraestructure.Repositories
{
    public class PostulantRepository : IPostulantRepository
    {
        private readonly DataBaseContext context;

        public PostulantRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<Postulant> FindByDocument(Document document)
        {
            return await context.Postulants.Where(x => x.Document.Dni == document.Dni && x.Document.Country == document.Country).FirstOrDefaultAsync();
        }

        public async Task<Postulant> FindByEmail(string Email)
        {
            return await context.Postulants.Where(x => x.Email == Email).FirstOrDefaultAsync();
        }

        public async Task<Postulant> FindById(PostulantId postulantId)
        {
            return await context.Postulants.Where(x => x.Id == (int)postulantId).Include(x => x.SkillPostulants).ThenInclude(y => y.Skill).FirstOrDefaultAsync();
        }

        public async Task<Postulant> FindByPhone(Phone phone)
        {
            return await context.Postulants.Where(x => x.Phone.Number == phone.Number && x.Phone.Operator == phone.Operator && x.Phone.ZipCode == phone.ZipCode).FirstOrDefaultAsync();
        }

        public void Remove(Postulant postulant)
        {
            context.Postulants.Remove(postulant);
        }

        public async Task Save(Postulant postulant)
        {
            await context.Postulants.AddAsync(postulant);
        }

        public void Update(Postulant postulant)
        {
            context.Postulants.Update(postulant);
        }
    }
}