using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier
{
    public class ImmobilierValidator:AbstractValidator<CreateImmobilierCommand>
    {
        public ImmobilierValidator()
        {
            RuleFor(immobilier => immobilier.ImmobilierDto.Avance).NotEmpty();
            RuleFor(immobilier => immobilier.ImmobilierDto.Prix).GreaterThan(5000);
            RuleFor(immobilier => immobilier.ImmobilierDto.Localisation).NotEmpty();
            RuleFor(immobilier => immobilier.ImmobilierDto.TypeImmobilier).NotEmpty();
            RuleFor(immobilier => immobilier.ImmobilierDto.TypeVente).NotEmpty();
            RuleFor(immobilier => immobilier.ImmobilierDto.UtilisateurId).NotEmpty();

        }
    }
}
