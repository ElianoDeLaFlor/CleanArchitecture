using AutoMapper;
using CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierById;
using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Dto;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Test.Mocks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Test.Immobilier.Queries
{
    public class GetImmobilierByIdQueryHandlerTests
    {
        //private readonly IMapper _mapper;
        private readonly Mock<IImmobilierRepository> _mockImmobilierRepository;

        public GetImmobilierByIdQueryHandlerTests()
        {
            _mockImmobilierRepository = RepositoryMocks.GetImmobilier_ById("12346");
            // Configure AutoMapper
            //var mapperConfiguration = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<AutoMapperProfile>();
            //});
        }

        [Fact]
        public async Task GetImmobilierItem()
        {
            //Arrange
            string id="12346";
            var handler =new GetImmobilierByIdQueryHandler(_mockImmobilierRepository.Object);
            //Act
            var result = await handler.Handle(new GetImmobilierByIdQuery(id), CancellationToken.None);
            //Assert
            result.ShouldBeOfType<ServiceResponse<Entity.Immobilier>>();
            result.Data?.Id.ShouldBe(id);
        }

        [Fact]
        public async Task Handle_ValideId_ResturnsSuccess()
        {
            //Arrange
            var expected = new ServiceResponse<Entity.Immobilier>
            {
                Data = new Entity.Immobilier { Id = "1" },
                Success = true,
                Message = "Success"
            };

            //var _reposMock=new Mock<IImmobilierRepository>();
            _mockImmobilierRepository.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                                     .Returns(Task.FromResult(expected));

            var request = new GetImmobilierByIdQuery("1");
            var handler=new GetImmobilierByIdQueryHandler(_mockImmobilierRepository.Object);
            //Act
            var actual = await handler.Handle(request, CancellationToken.None);

            //Assert
            actual.ShouldNotBeNull();
            actual.Data?.Id.ShouldBe("1");
            actual.Success.ShouldBeTrue();
            actual.Message.ShouldBe(expected.Message);
        }

        [Fact]
        public async Task Handle_InvalideId_ResturnsError()
        {
            //Arrange
            var expected = new ServiceResponse<Entity.Immobilier>
            {
                Data = new Entity.Immobilier { Id = "1" },
                Success = false,
                Message = "error"
            };

            //var _reposMock=new Mock<IImmobilierRepository>();
            _mockImmobilierRepository.Setup(r => r.GetByIdAsync(It.IsAny<string>()))
                                     .Returns(Task.FromResult(expected));

            var request = new GetImmobilierByIdQuery("1");
            var handler = new GetImmobilierByIdQueryHandler(_mockImmobilierRepository.Object);
            //Act
            var actual = await handler.Handle(request, CancellationToken.None);

            //Assert
            actual.ShouldNotBeNull();
            actual.Data?.Id.ShouldBe("1");
            actual.Success.ShouldBeFalse();
            actual.Message.ShouldBe(expected.Message);
        }
    }
}
