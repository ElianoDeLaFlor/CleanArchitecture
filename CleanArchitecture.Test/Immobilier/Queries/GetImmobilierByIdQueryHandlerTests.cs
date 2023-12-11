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
    }
}
