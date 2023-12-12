using CleanArchitecture.Application.Features.Immobilier.Commands.DeleteImmobilier;
using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Test.Mocks;
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
    public class DeleteImmobilierCommandTest
    {
        private readonly Mock<IImmobilierRepository> mockRepository;

        
        public DeleteImmobilierCommandTest()
        {
            mockRepository = new Mock<IImmobilierRepository>();
        }

        [Fact]
        public async Task Handle_ValidId_ReturnSuccess()
        {
            // Arrange   
            var request = new DeleteImmobilierCommand("1");
            var entity = new Entity.Immobilier { Id = "1" };
            
            mockRepository.Setup(r => r.GetByIdAsync(request.Id))
                .ReturnsAsync(new ServiceResponse<Entity.Immobilier> { Success = true,Data=entity });
            
            mockRepository.Setup(r => r.DeleteAsync(request.Id))
                .ReturnsAsync(new ServiceResponse<Entity.Immobilier> { Success = true, Data = entity });

            var handler = new DeleteImmobilierCommandHandler(mockRepository.Object);

            //Act
            var actual = await handler.Handle(request, CancellationToken.None);

            //Assert
            actual.ShouldBeOfType<ServiceResponse<Entity.Immobilier>>();
            actual.ShouldNotBeNull();
            actual.Success.ShouldBeTrue();
            actual.Data?.Id.ShouldBe("1");
            actual.Data.ShouldBeSameAs(entity);

            mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<string>()), Times.Once);
            mockRepository.Verify(r => r.DeleteAsync(It.IsAny<string>()), Times.Once);

        }

        [Fact]
        public async Task Handle_InValidId_ReturnError()
        {
            // Arrange   
            var request = new DeleteImmobilierCommand("1");
            var entity = new Entity.Immobilier { Id = "1" };

            mockRepository.Setup(r => r.GetByIdAsync(request.Id))
                .ReturnsAsync(new ServiceResponse<Entity.Immobilier> { Success = false, Data = null });

            mockRepository.Setup(r => r.DeleteAsync(request.Id))
                .ReturnsAsync(new ServiceResponse<Entity.Immobilier> { Success = true, Data = entity });

            var handler = new DeleteImmobilierCommandHandler(mockRepository.Object);

            //Act
            var actual = await handler.Handle(request, CancellationToken.None);

            //Assert
            actual.ShouldBeOfType<ServiceResponse<Entity.Immobilier>>();
            actual.ShouldNotBeNull();
            actual.Success.ShouldBeFalse();
            actual.Data.ShouldBeNull();


            mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<string>()), Times.Once);
            mockRepository.Verify(r => r.DeleteAsync(It.IsAny<string>()), Times.Never);

        }

        [Fact]
        public async Task Handle_DeleteAsyncThrowException_ReturnError()
        {
            // Arrange   
            var request = new DeleteImmobilierCommand("1");
            var entity = new Entity.Immobilier { Id = "1" };

            mockRepository.Setup(r => r.GetByIdAsync(request.Id))
                .ReturnsAsync(new ServiceResponse<Entity.Immobilier> { Success = true, Data = entity });

            mockRepository.Setup(r => r.DeleteAsync(request.Id))
                .ReturnsAsync(new ServiceResponse<Entity.Immobilier> { Success = false, Data = null });

            var handler = new DeleteImmobilierCommandHandler(mockRepository.Object);

            //Act
            var actual = await handler.Handle(request, CancellationToken.None);

            //Assert
            actual.ShouldBeOfType<ServiceResponse<Entity.Immobilier>>();
            actual.ShouldNotBeNull();
            actual.Success.ShouldBeFalse();
            actual.Data.ShouldBeNull();

            mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<string>()), Times.Once);
            mockRepository.Verify(r => r.DeleteAsync(It.IsAny<string>()), Times.Once);

        }
    }
}
