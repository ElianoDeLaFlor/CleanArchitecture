using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierByReff
{
    public class GetImmobilierByReffQueryHandler : IRequestHandler<GetImmobilierByReffQuery, ServiceResponse<Entity.Immobilier>>
    {
        private readonly IImmobilierRepository _immobilierRepository;

        public GetImmobilierByReffQueryHandler(IImmobilierRepository repository)
        {
            _immobilierRepository = repository;
        }
        public async Task<ServiceResponse<Entity.Immobilier>> Handle(GetImmobilierByReffQuery request, CancellationToken cancellationToken)
        {
            return await _immobilierRepository.GetByReffAsync(request.Reff);
        }
    }
}
