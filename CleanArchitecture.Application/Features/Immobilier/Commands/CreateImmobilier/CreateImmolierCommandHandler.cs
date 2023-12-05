
using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Response;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity = CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier
{
    public class CreateImmobilierCommandHandler : IRequestHandler<CreateImmobilierCommand, ServiceResponse<Entity.Immobilier>>
    {
        private readonly IImmobilierRepository _repository;
        private readonly IMapper _mapper;

        public CreateImmobilierCommandHandler(IImmobilierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Entity.Immobilier>> Handle(CreateImmobilierCommand request, CancellationToken cancellationToken)
        {
            
            
                var immobilier = _mapper.Map<Entity.Immobilier>(request.ImmobilierDto);

            return await _repository.CreateAsync(immobilier);
        }
    }
}
