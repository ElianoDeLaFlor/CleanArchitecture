using CleanArchitecture.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierByReff
{
    public record GetImmobilierByReffQuery(string Reff):IRequest<ServiceResponse<Entity.Immobilier>>;
}
