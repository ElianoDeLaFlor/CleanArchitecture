using CleanArchitecture.Domain.Response;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class ImmobilierRepository : IImmobilierRepository
    {
        private readonly DataContext _context;
        public ImmobilierRepository(DataContext context) { _context = context; }
        public async Task<ServiceResponse<string>> AddPhotoAsync(Immobilier entity)
        {
            ServiceResponse<string> response = new();
            try
            {
                entity.DateDeModification = DateTime.Now;
               _= await _context.immobiliers.AddAsync(entity);
              _=  await _context.SaveChangesAsync();

                response.Success = true;
                response.Message = "Photo added successfully";
                response.Data = entity.Photos;    
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
                return response;
            }
        }

        public async Task<ServiceResponse<string>> AddVideoAsync(Immobilier entity)
        {
            ServiceResponse<string> response = new();
            try
            {
                entity.DateDeModification = DateTime.Now;
                _ = _context.Entry(entity).State=EntityState.Modified;
                _ = await _context.SaveChangesAsync();

                response.Success = true;
                response.Message = "Photo added successfully";
                response.Data = entity.Photos;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
                return response;
            }
        }

        public async Task<ServiceResponse<List<Immobilier>>> AllAsync(bool published)
        {
            ServiceResponse<List<Immobilier>> response = new();
            try
            {
                var rslt = await (from item in _context.immobiliers where item.Publier == true select item).ToListAsync();
                response.Success = true;
                response.Message = "Operation completed successfully";
                response.Data = rslt;

                return response;

            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;

                return response;
            }
        }

        public Task<ServiceResponse<Immobilier>> CreateAsync(Immobilier entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Immobilier>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> DeleteByImmobilierAndTypeImmobilierAsync(string immobilierid, int typeimmobilierid)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Immobilier>> DuplicateImmobilier(string immobilierId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Immobilier>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Immobilier>> GetByReffAsync(string label)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetFavoriteImmobilier(bool state)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetImmobilierByTypeImmobilier(int typeImmobilierId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetImmobilierByTypeImmobilier(int typeImmobilierId, int pagenumber = 1, int itemperpage = 25)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetImmobilierByTypeVente(int typeVenteId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetImmobilierByTypeVente(int typeVenteId, int pagenumber = 1, int itemperpage = 25)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetSimillarImmobilier(int typeImmobilierId, int typeVenteId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetSimillarTypeImmobilier(int typeImmobilierId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> GetSimillarTypeVente(int typeVenteId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> ImmobilierByRange(int pagenumber = 1, int itemperpage = 25)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> ImmobilierCount(bool state)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> ImmobilierCount()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Immobilier>>> ImmobilierResearchByRange(string criteria, int pagenumber = 1, int itemperpage = 25)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> ImmobilierSearchCount(string criteria)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> PublishedAsync(string id, bool state)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Immobilier>> UpdateAsync(Immobilier entity)
        {
            throw new NotImplementedException();
        }
    }
}
