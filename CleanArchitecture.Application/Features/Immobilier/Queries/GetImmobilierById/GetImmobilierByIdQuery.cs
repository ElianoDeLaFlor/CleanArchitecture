﻿
using CleanArchitecture.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Entity= CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierById
{
    public record GetImmobilierByIdQuery(int Id) : IRequest<ServiceResponse<Entity.Immobilier>>;
}
