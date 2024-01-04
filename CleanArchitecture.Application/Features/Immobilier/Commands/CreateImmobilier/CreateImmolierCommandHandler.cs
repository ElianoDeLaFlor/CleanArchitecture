
using AutoMapper;
using Azure;
using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier
{
    public class CreateImmobilierCommandHandler : IRequestHandler<CreateImmobilierCommand, ServiceResponse<Entity.Immobilier>>
    {
        private readonly IImmobilierRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateImmobilierCommand> _validator;

        public CreateImmobilierCommandHandler(IImmobilierRepository repository, IMapper mapper, IValidator<CreateImmobilierCommand> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<ServiceResponse<Entity.Immobilier>> Handle(CreateImmobilierCommand request, CancellationToken cancellationToken)
        {
            //validate the data
            var result= await _validator.ValidateAsync(request, cancellationToken);

            if(result.IsValid)
            {
                var immobilier = _mapper.Map<Entity.Immobilier>(request.ImmobilierDto);

                return await _repository.CreateAsync(immobilier);
            }

            var response = new ServiceResponse<Entity.Immobilier>
            {
                Success = false,
                Message = result.ToString(),
                Data = null
            };
            return response;
                
        }
    }
}
