using System.Collections.Generic;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Shared.Domain.Model.Phone;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Resume.Domain.Repositories
{
    public interface IPostulantRepository
    {
        Task<Postulant> FindById(PostulantId postulantId);

        Task Save(Postulant postulant);

        Task<Postulant> FindByEmail(string Email);

        Task<Postulant> FindByPhone(Phone phone);

        Task<Postulant> FindByDocument(Document document);

        void Update(Postulant postulant);

        void Remove(Postulant postulant);
    }
}