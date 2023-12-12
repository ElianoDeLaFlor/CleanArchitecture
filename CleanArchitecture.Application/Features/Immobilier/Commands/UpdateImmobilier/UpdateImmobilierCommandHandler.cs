using AutoMapper;
using CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier;
using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Features.Immobilier.Commands.UpdateImmobilier
{
    public class UpdateImmobilierCommandHandler : IRequestHandler<UpdateImmobilierCommand, ServiceResponse<Entity.Immobilier>>
    {
        private readonly IImmobilierRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateImmobilierCommand> _validator;

        public UpdateImmobilierCommandHandler(IImmobilierRepository repository, IMapper mapper, IValidator<UpdateImmobilierCommand> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<ServiceResponse<Entity.Immobilier>> Handle(UpdateImmobilierCommand request, CancellationToken cancellationToken)
        {
            //validate the data
            var result = await _validator.ValidateAsync(request, cancellationToken);
            
            if (result.IsValid)
            {
                var immobilier = _mapper.Map<Entity.Immobilier>(request.ImmobilierDto);
                return await _repository.UpdateAsync(request.Id,immobilier);
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
