using CleanArchitecture.Domain.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Features.Immobilier.Queries.GetAllImmobilier
{
    public record GetAllImmobilierQuery(bool? published=null):IRequest<ServiceResponse<List<Entity.Immobilier>>>;
}
