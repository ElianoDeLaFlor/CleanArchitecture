
using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierById
{
    public class GetImmobilierByIdQueryHandler : IRequestHandler<GetImmobilierByIdQuery, ServiceResponse<Entity.Immobilier>>
    {
        //repository injection
        private readonly ImmobilierRepository _immobilierRepository;

        public GetImmobilierByIdQueryHandler(ImmobilierRepository repository)
        {
            _immobilierRepository = repository;
        }

        public async Task<ServiceResponse<Entity.Immobilier>> Handle(GetImmobilierByIdQuery request, CancellationToken cancellationToken)
        {
            return await _immobilierRepository.GetByIdAsync(request.Id);
        }
    }


}
