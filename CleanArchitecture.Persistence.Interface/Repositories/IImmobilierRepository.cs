using CleanArchitecture.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Persistence.Entities;

namespace CleanArchitecture.Persistence.Repositories
{
    public interface IImmobilierRepository:IGenericRepository<ImmobilierEntity>
    {
        Task<ServiceResponse<ImmobilierEntity>> GetByReffAsync(string label);
        Task<ServiceResponse<string>> AddPhotoAsync(ImmobilierEntity entity);
        Task<ServiceResponse<string>> AddVideoAsync(ImmobilierEntity entity);
        Task<ServiceResponse<bool>> PublishedAsync(string id, bool state);
        Task<ServiceResponse<ImmobilierEntity>> DeleteByImmobilierAndTypeImmobilierAsync(string immobilierid, int typeimmobilierid);
        Task<ServiceResponse<int>> ImmobilierCount(bool state);
        Task<ServiceResponse<int>> ImmobilierCount();
        Task<ServiceResponse<int>> ImmobilierSearchCount(string criteria);
        Task<ServiceResponse<List<ImmobilierEntity>>> ImmobilierResearchByRange(string criteria, int pagenumber = 1, int itemperpage = 25);
        Task<ServiceResponse<List<ImmobilierEntity>>> ImmobilierByRange(int pagenumber = 1, int itemperpage = 25);
        Task<ServiceResponse<ImmobilierEntity>> DuplicateImmobilier(string immobilierId);
        Task<ServiceResponse<List<ImmobilierEntity>>> GetSimillarTypeImmobilier(int typeImmobilierId);
        Task<ServiceResponse<List<ImmobilierEntity>>> GetSimillarTypeVente(int typeVenteId);
        Task<ServiceResponse<List<ImmobilierEntity>>> GetSimillarImmobilier(int typeImmobilierId, int typeVenteId);
        Task<ServiceResponse<List<ImmobilierEntity>>> GetImmobilierByTypeVente(int typeVenteId);
        Task<ServiceResponse<List<ImmobilierEntity>>> GetImmobilierByTypeVente(int typeVenteId, int pagenumber = 1, int itemperpage = 25);
        Task<ServiceResponse<List<ImmobilierEntity>>> GetImmobilierByTypeImmobilier(int typeImmobilierId);
        Task<ServiceResponse<List<ImmobilierEntity>>> GetImmobilierByTypeImmobilier(int typeImmobilierId, int pagenumber = 1, int itemperpage = 25);
        Task<ServiceResponse<List<ImmobilierEntity>>> GetFavoriteImmobilier(bool state);
        Task<ServiceResponse<List<ImmobilierEntity>>> AllAsync(bool published);
    }
}
