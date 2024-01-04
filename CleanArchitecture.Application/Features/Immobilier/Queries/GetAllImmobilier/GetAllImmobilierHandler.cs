using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Features.Immobilier.Queries.GetAllImmobilier
{
    public class GetAllImmobilierHandler : IRequestHandler<GetAllImmobilierQuery, ServiceResponse<List<Entity.Immobilier>>>
    {
        private readonly IImmobilierRepository _immobilierRepository;

        public GetAllImmobilierHandler(IImmobilierRepository immobilierRepository)
        {
            _immobilierRepository = immobilierRepository;
        }

        public async Task<ServiceResponse<List<Entity.Immobilier>>> Handle(GetAllImmobilierQuery request, CancellationToken cancellationToken)
        {

            if(request.published.HasValue)
            {
                return await _immobilierRepository.AllAsync(request.published.Value);
            }
            else
            {
                return await _immobilierRepository.GetAllAsync();
            }
        }
    }
}
