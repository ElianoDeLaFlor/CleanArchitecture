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
using CleanArchitecture.Domain.Utility;

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

        public async Task<ServiceResponse<Immobilier>> CreateAsync(Immobilier entity)
        {
            ServiceResponse<Immobilier> response = new();
            try
            {
                entity.DateDeCreation= DateTime.Now;
                entity.DateDeModification=entity.DateDeCreation;
                entity.Reff = Helper.Code(8);

                _= await _context.immobiliers.AddAsync(entity);

                _=_context.SaveChanges();
                
                response.Success = true;
                response.Message = "Operation completed successfully";
                response.Data = entity;

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

        public async Task<ServiceResponse<Immobilier>> DeleteAsync(string id)
        {
            ServiceResponse<Immobilier> response = new();
            try
            {
                var itemToDelete = await _context.immobiliers.FindAsync(id);

                if(itemToDelete != null)
                {
                    _ = _context.immobiliers.Remove(itemToDelete);

                    _context.SaveChanges();

                    response.Success = true;
                    response.Message = "Operation complete successfully";
                    response.Data = itemToDelete;

                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Item to delete can not be find";
                    response.Data = null;
                    return response;
                }

                
            }
            catch (Exception ex)
            {
                response.Success=false;
                response.Message = ex.Message;
                response.Data = null;
                return response;
            }
        }

        public async Task<ServiceResponse<Immobilier>> DeleteByImmobilierAndTypeImmobilierAsync(string immobilierid, int typeimmobilierid)
        {
            ServiceResponse<Immobilier> response = new();
            try
            {
                var itemToDelete = await (from item in _context.immobiliers where item.Id==immobilierid && item.TypeImmobilier==typeimmobilierid select item).SingleAsync();

                if (itemToDelete != null)
                {
                    _ = _context.immobiliers.Remove(itemToDelete);

                    _context.SaveChanges();

                    response.Success = true;
                    response.Message = "Operation complete successfully";
                    response.Data = itemToDelete;

                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Item to delete can not be find";
                    response.Data = null;
                    return response;
                }


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Data = null;
                return response;
            }
        }

        public async Task<ServiceResponse<Immobilier>> DuplicateImmobilier(string immobilierId)
        {
            ServiceResponse<Immobilier> response = new();

            try
            {
                //get immobilier to duplicate
                var itemToDuplicate= await _context.immobiliers.Where(i=>i.Id==immobilierId).SingleAsync();
                
                if (itemToDuplicate != null)
                {
                    var itemDuplicated=new Immobilier();
                    itemDuplicated = itemToDuplicate;
                    itemDuplicated.DateDeCreation = DateTime.Now;
                    itemDuplicated.DateDeModification = itemDuplicated.DateDeCreation;
                    itemDuplicated.Favorit = false;
                    itemDuplicated.Publier = false;
                    itemDuplicated.Finaliser = false;
                    itemDuplicated.Reff = Helper.Code(8);

                    _=_context.Add(itemDuplicated);

                    response.Success = true;
                    response.Message = "Item duplicate successfully";
                    response.Data = itemDuplicated;

                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Item to duplicate can not be find";
                    response.Data = null;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Success = true;
                response.Message = ex.Message;
                response.Data = null;

                return response;
            }
        }

        public Task<ServiceResponse<List<Immobilier>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Immobilier>> GetByIdAsync(string id)
        {
            ServiceResponse<Immobilier> response = new();
            try
            {
                var rslt = await(from item in _context.immobiliers where item.Id == id select item).SingleAsync();
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
