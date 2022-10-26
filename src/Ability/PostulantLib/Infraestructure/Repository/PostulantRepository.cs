using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Ability.PostulantLib.Infraestructure.Repository
{
    public class PostulantRepository : IPostulantRepository
    {
        DataBaseContext db;

        public PostulantRepository(DataBaseContext db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<Postulant>> FindAll()
        {
            return await db.Postulants.ToListAsync();
        }

        public async Task<Postulant> FindPostulantByDocument(PostulantDocument document)
        {
            return await db.Postulants.Where(p => p.Document.Value == (string)document).FirstOrDefaultAsync();
        }

        public async Task<Postulant> FindPostulantByEmail(PostulantEmail email)
        {
            return await db.Postulants.Where(p => p.Email.Value == (string)email).FirstOrDefaultAsync();
        }

        public async Task<Postulant> FindPostulantById(PostulantId id)
        {
            return await db.Postulants.FindAsync((int)id);
        }

        public async Task<Postulant> FindPostulantByNumber(PostulantNumber number)
        {
            return await db.Postulants.Where(p => p.Number.Number == (int)number).FirstOrDefaultAsync();
        }

        public async Task AddPostulant(Postulant postulant)
        {
            await db.Postulants.AddAsync(postulant);
        }

        public void DeletePostulant(Postulant postulant)
        {
            db.Postulants.Remove(postulant);
        }

        public void UpdatePostulant(Postulant postulant)
        {
            db.Postulants.Update(postulant);
        }

        public async Task<Postulant> FindPostulantInformationById(PostulantId id)
        {
            return await db.Postulants
                .Where(x => x.Id == (int)id)
                .Include(x => x.SkillPostulants)
                    .ThenInclude(y => y.Skill)
                .FirstOrDefaultAsync();
        }
    }
}