using CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Immobilier.Commands.UpdateImmobilier
{
    public class UpdateImmobilierValidator: AbstractValidator<UpdateImmobilierCommand>
    {
        public UpdateImmobilierValidator()
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
