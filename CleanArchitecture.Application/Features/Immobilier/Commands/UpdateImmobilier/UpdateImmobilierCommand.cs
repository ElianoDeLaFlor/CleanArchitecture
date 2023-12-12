using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Features.Immobilier.Commands.UpdateImmobilier
{
    public record UpdateImmobilierCommand(ImmobilierDto ImmobilierDto) : IRequest<ServiceResponse<Entity.Immobilier>>;
}
