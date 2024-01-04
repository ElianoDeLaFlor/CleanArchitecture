using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Features.Immobilier.Commands.DeleteImmobilier
{
    public class DeleteImmobilierCommandHandler : IRequestHandler<DeleteImmobilierCommand, ServiceResponse<Entity.Immobilier>>
    {
        private readonly IImmobilierRepository _repository;

        public DeleteImmobilierCommandHandler(IImmobilierRepository repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse<Entity.Immobilier>> Handle(DeleteImmobilierCommand request, CancellationToken cancellationToken)
        {
            //check if the item to delete exist
            var item= await _repository.GetByIdAsync(request.Id);
            
            if (item.Success)
            {
                //item to delete exist
                return await _repository.DeleteAsync(request.Id);
            }
            //item to delete does not exist
            return item;
            
        }
    }
}
