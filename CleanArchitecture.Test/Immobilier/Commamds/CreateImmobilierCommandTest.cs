using AutoMapper;
using CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier;
using CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierById;
using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Test.Mocks;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Test.Immobilier.Commamds
{
    public class CreateImmobilierCommandTest
    {
        private Mock<IImmobilierRepository> _immobilierRepositoryMock;
        private readonly IMapper _mapper;
        private Mock<IValidator<CreateImmobilierCommand>> _validatorMock;

        public CreateImmobilierCommandTest()
        {

            _immobilierRepositoryMock=new Mock<IImmobilierRepository>();
            //Configure AutoMapper
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _validatorMock = new Mock<IValidator<CreateImmobilierCommand>>();
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CreateImmobilierCommand>(), CancellationToken.None))
                .Returns(Task.FromResult(new ValidationResult()));

        }

        [Fact]
        public async Task CreateAsync_NormalInsertion_ShouldInsertItem()
        {
            //Arrange
            _immobilierRepositoryMock = RepositoryMocks.AddImmobillier(new Entity.Immobilier { Id = "1234", Finaliser = true });

            var handler = new CreateImmobilierCommandHandler(_immobilierRepositoryMock.Object,_mapper, _validatorMock.Object);
            
            //Act
            var result = await handler.Handle(new CreateImmobilierCommand(new ImmobilierDto { Avance = "2 mois", Prix=12000}), CancellationToken.None);

            _immobilierRepositoryMock = RepositoryMocks.GetAllImmobillier();
            var lst= await _immobilierRepositoryMock.Object.GetAllAsync();
            
            //Assert
            result.Data?.Id.ShouldBe("1234");
            result.Data?.Finaliser.ShouldBeTrue();
            lst.Data?.Count.ShouldBe(4);

            _validatorMock.Verify(x => x.ValidateAsync(It.IsAny<CreateImmobilierCommand>(),CancellationToken.None), Times.Once());
        }

        [Fact]
        public async Task CreateAsync_ValidationError_ShouldNotInsertItem()
        {
            //Arrange
            

            _validatorMock = new Mock<IValidator<CreateImmobilierCommand>>();
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CreateImmobilierCommand>(), CancellationToken.None))
                .Returns(Task.FromResult(new ValidationResult(
                    new List<ValidationFailure> 
                    { 
                        new ValidationFailure("Avance", "error") 
                    })
                ));

            var handler = new CreateImmobilierCommandHandler(_immobilierRepositoryMock.Object, _mapper, _validatorMock.Object);

            //Act
            var result = await handler.Handle(new CreateImmobilierCommand(new ImmobilierDto { Avance = "2 mois", Prix = 12000 }), CancellationToken.None);

            _immobilierRepositoryMock = RepositoryMocks.GetAllImmobillier();
            var lst = await _immobilierRepositoryMock.Object.GetAllAsync();

            //Assert
            result.Data.ShouldBe(null);
            result.Message.ShouldBe("error");
            result.Success.ShouldBeFalse();

            _validatorMock.Verify(x => x.ValidateAsync(It.IsAny<CreateImmobilierCommand>(), CancellationToken.None), Times.Once());
        }
    }
}
