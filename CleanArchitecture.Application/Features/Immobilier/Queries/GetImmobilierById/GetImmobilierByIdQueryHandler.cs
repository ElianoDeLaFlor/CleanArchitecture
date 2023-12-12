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

namespace CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierById
{
    public class GetImmobilierByIdQueryHandler : IRequestHandler<GetImmobilierByIdQuery, ServiceResponse<Entity.Immobilier>>
    {
        private readonly IImmobilierRepository _immobilierRepository;

        //repository injection
        public GetImmobilierByIdQueryHandler(IImmobilierRepository repository)
        {
            _immobilierRepository = repository;
        }

        public async Task<ServiceResponse<Entity.Immobilier>> Handle(GetImmobilierByIdQuery request, CancellationToken cancellationToken)
        {
            var r= await _immobilierRepository.GetByIdAsync(request.Id);
            return r;
        }
    }


}
