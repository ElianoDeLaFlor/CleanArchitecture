using CleanArchitecture.Domain.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IImmobilierRepository:IGenericRepository<Immobilier>
    {
        Task<ServiceResponse<Immobilier>> GetByReffAsync(string label);
        Task<ServiceResponse<string>> AddPhotoAsync(Immobilier entity);
        Task<ServiceResponse<string>> AddVideoAsync(Immobilier entity);
        Task<ServiceResponse<bool>> PublishedAsync(string id, bool state);
        Task<ServiceResponse<int>> DeleteByImmobilierAndTypeImmobilierAsync(string immobilierid, int typeimmobilierid);
        Task<ServiceResponse<int>> ImmobilierCount(bool state);
        Task<ServiceResponse<int>> ImmobilierCount();
        Task<ServiceResponse<int>> ImmobilierSearchCount(string criteria);
        Task<ServiceResponse<List<Immobilier>>> ImmobilierResearchByRange(string criteria, int pagenumber = 1, int itemperpage = 25);
        Task<ServiceResponse<List<Immobilier>>> ImmobilierByRange(int pagenumber = 1, int itemperpage = 25);
        Task<ServiceResponse<Immobilier>> DuplicateImmobilier(string immobilierId);
        Task<ServiceResponse<List<Immobilier>>> GetSimillarTypeImmobilier(int typeImmobilierId);
        Task<ServiceResponse<List<Immobilier>>> GetSimillarTypeVente(int typeVenteId);
        Task<ServiceResponse<List<Immobilier>>> GetSimillarImmobilier(int typeImmobilierId, int typeVenteId);
        Task<ServiceResponse<List<Immobilier>>> GetImmobilierByTypeVente(int typeVenteId);
        Task<ServiceResponse<List<Immobilier>>> GetImmobilierByTypeVente(int typeVenteId, int pagenumber = 1, int itemperpage = 25);
        Task<ServiceResponse<List<Immobilier>>> GetImmobilierByTypeImmobilier(int typeImmobilierId);
        Task<ServiceResponse<List<Immobilier>>> GetImmobilierByTypeImmobilier(int typeImmobilierId, int pagenumber = 1, int itemperpage = 25);
        Task<ServiceResponse<List<Immobilier>>> GetFavoriteImmobilier(bool state);
        Task<ServiceResponse<List<Immobilier>>> AllAsync(bool published);
    }
}
