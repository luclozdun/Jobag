using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;

namespace Jobag.src.Ability.PostulantLib.Domain.Repository
{
    public interface IPostulantRepository
    {
        Task<IEnumerable<Postulant>> FindAll();
        Task<Postulant> FindPostulantById(PostulantId id);

        Task<Postulant> FindPostulantInformationById(PostulantId id);

        Task<Postulant> FindPostulantByEmail(PostulantEmail email);

        Task<Postulant> FindPostulantByDocument(PostulantDocument document);

        Task<Postulant> FindPostulantByNumber(PostulantNumber number);

        Task AddPostulant(Postulant postulant);

        void UpdatePostulant(Postulant postulant);
        void DeletePostulant(Postulant postulant);
    }
}