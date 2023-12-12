using AutoMapper;
using CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier;
using CleanArchitecture.Application.Features.Immobilier.Commands.UpdateImmobilier;
using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Entities;
using CleanArchitecture.Persistence.Interfaces;
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
    public class UpdateImmobilierCommandTest
    {
        private readonly Mock<IImmobilierRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IValidator<UpdateImmobilierCommand>> _validatorMock;

        public UpdateImmobilierCommandTest()
        {
            _repositoryMock = new ();
            

            _mapperMock = new Mock<IMapper>();

            _mapperMock.Setup(x => x.Map<Entity.Immobilier>(It.IsAny<ImmobilierDto>())).Returns(new Entity.Immobilier { Prix = 1234, Publier = true });
            
                _validatorMock = new();
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<UpdateImmobilierCommand>(), CancellationToken.None))
                .Returns(Task.FromResult(new ValidationResult()));
        }

        [Fact]
        public async Task Handle_ValideData_ShouldUpdate()
        {
            //Arrange
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<string>(),It.IsAny<Entity.Immobilier>()))
                           .Returns(Task.FromResult(new ServiceResponse<Entity.Immobilier> { Success = true, Data = new Entity.Immobilier { Prix = 12345, Publier = true }, Message = "success" }));
            
            var request = new UpdateImmobilierCommand("12345",new ImmobilierDto { Prix = 12345, Publier = true });
            
            var handler= new UpdateImmobilierCommandHandler(_repositoryMock.Object, _mapperMock.Object, _validatorMock.Object);

            //Act
            var actual = await handler.Handle(request, CancellationToken.None);
            
            //Assert
            actual.ShouldNotBeNull();
            actual.Success.ShouldBeTrue();
            actual.Data.ShouldNotBeNull();

            _mapperMock.Verify(x => x.Map<Entity.Immobilier>(It.IsAny<ImmobilierDto>()), Times
                .Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<string>(), It.IsAny<Entity.Immobilier>()), Times.Once);


        }

        [Fact]
        public async Task Handle_InvalideData_ShouldNotUpdate()
        {
            //Arrange
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<string>(), It.IsAny<Entity.Immobilier>()))
                           .Returns(Task.FromResult(new ServiceResponse<Entity.Immobilier> { Success = true, Data = new Entity.Immobilier { Prix = 12345, Publier = true }, Message = "success" }));

            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<UpdateImmobilierCommand>(), CancellationToken.None))
                .Returns(Task.FromResult(new ValidationResult(
                    new List<ValidationFailure>
                    {
                        new ValidationFailure("Avance", "error")
                    })
                ));

            var request = new UpdateImmobilierCommand("12345", new ImmobilierDto { Prix = 12345, Publier = true });

            var handler = new UpdateImmobilierCommandHandler(_repositoryMock.Object, _mapperMock.Object, _validatorMock.Object);

            //Act
            var actual = await handler.Handle(request, CancellationToken.None);

            //Assert
            actual.ShouldNotBeNull();
            actual.Success.ShouldBeFalse();
            actual.Data.ShouldBeNull();
            actual.Message.ShouldBe("error");

            _mapperMock.Verify(x => x.Map<Entity.Immobilier>(It.IsAny<ImmobilierDto>()), Times
                .Never);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<string>(), It.IsAny<Entity.Immobilier>()), Times.Never);


        }

        [Fact]
        public async Task Handle_ValideDataUpdateTrhrowError_ShouldUpdate()
        {
            //Arrange
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<string>(), It.IsAny<Entity.Immobilier>()))
                           .Returns(Task.FromResult(new ServiceResponse<Entity.Immobilier> { Success = false, Data = null, Message = "error" }));

            var request = new UpdateImmobilierCommand("12345", new ImmobilierDto { Prix = 12345, Publier = true });

            var handler = new UpdateImmobilierCommandHandler(_repositoryMock.Object, _mapperMock.Object, _validatorMock.Object);

            //Act
            var actual = await handler.Handle(request, CancellationToken.None);

            //Assert
            actual.ShouldNotBeNull();
            actual.Success.ShouldBeFalse();
            actual.Data.ShouldBeNull();
            actual.Message.ShouldBe("error");

            _mapperMock.Verify(x => x.Map<Entity.Immobilier>(It.IsAny<ImmobilierDto>()), Times
                .Once);
            _repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<string>(), It.IsAny<Entity.Immobilier>()), Times.Once);


        }
    }
}
