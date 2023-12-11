using Autofac.Extras.Moq;
using CleanArchitecture.Domain.Response;
using CleanArchitecture.Persistence.Interfaces;
using CleanArchitecture.Persistence.Repositories;
using Entity = CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Moq;
using AutoMapper;
using CleanArchitecture.Persistence.Dto;
using Autofac;
using CleanArchitecture.Persistence.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierById;
using Moq.EntityFrameworkCore;
using CleanArchitecture.Persistence.Entities;
using CleanArchitecture.Test.Mocks;
using System.Diagnostics.Contracts;
using Shouldly;
using Azure;
using System.Collections.Generic;
using System.CodeDom;
using System.Xml;
using Autofac.Core;

namespace CleanArchitecture.Test.Immobilier
{
    public class DataAccess
    {
        //"MethodName_Condition_ExpectedResult"

        private IMapper _mapper;
        private readonly Mock<DataContext> _contextMock = new();
        private readonly Mock<IMapper> _imapperMock = new();
        private readonly Mock<IImmobilierRepository> _mockImmobilierRepository;

        public DataAccess()
        {
            _mockImmobilierRepository = new Mock<IImmobilierRepository>();
            _contextMock.Setup(x => x.Set<ImmobilierEntity>()).ReturnsDbSet(listImmobilierEntity);
            //_contextMock.Setup(c => c.AddAsync(It.IsAny<ImmobilierEntity>()), CancellationToken.None);
                

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EnityMapperProfile>(); // Add your AutoMapper profile
            });
            _mapper=mapperConfiguration.CreateMapper();
            //_imapperMock.Setup(m=>m.cre);

        }

        [Fact]
        public async Task GetAllAsync_ReturnAllItemFromDatabase()
        {
            //Arrangement
            _mockImmobilierRepository
            .Setup(x => x.GetAllAsync())
                .Returns(OutputList()) ;

            _imapperMock.Setup(mapper => mapper.Map<List<Entity.Immobilier>>(It.IsAny<List<ImmobilierEntity>>()))
                .Returns(listImmobilier);
            
            var expected = listImmobilier;

            //Act
            var repos = new ImmobilierRepository(_contextMock.Object, _imapperMock.Object);
            var actual = await repos.GetAllAsync();
            
            //Assertion
            actual.ShouldNotBeNull();
            actual.Data?.Count.ShouldBe(expected.Count);
            
        }

        [Fact]
        public async Task CreateAsync_NormalInsertion_AddNewItemToTheDatabase()
        {


            // Arrange
            var mockMapper = new Mock<IMapper>();
            var mockContext = new Mock<DataContext>();
            var mockDbSet = new Mock<DbSet<ImmobilierEntity>>();

            // Mock the context and DbSet
            mockContext.Setup(x => x.Set<ImmobilierEntity>()).Returns(mockDbSet.Object);

            // Mock the mapper
            mockMapper.Setup(x => x.Map<ImmobilierEntity>(It.IsAny<Entity.Immobilier>())).Returns(new ImmobilierEntity());
            mockMapper.Setup(x => x.Map<Entity.Immobilier>(It.IsAny<ImmobilierEntity>())).Returns(new Entity.Immobilier());

            // Create the service
            var service = new ImmobilierRepository(mockContext.Object, mockMapper.Object);

            // Define a test entity
            var entity = new Entity.Immobilier();



            //Act
            var response = await service.CreateAsync(entity);


            // Assert
            Assert.True(response.Success);
            Assert.Equal("Operation completed successfully", response.Message);
            Assert.NotNull(response.Data);

            // Verify database interactions
            mockDbSet.Verify(x => x.AddAsync(It.IsAny<ImmobilierEntity>(), CancellationToken.None), Times.Once);
            mockContext.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Once);

            // Verify mapper interactions
            mockMapper.Verify(x => x.Map<ImmobilierEntity>(entity), Times.Once);
            mockMapper.Verify(x => x.Map<Entity.Immobilier>(It.IsAny<ImmobilierEntity>()), Times.Once);

        }

        [Fact]
        public async Task CreateAsync_DbContextError_ThowsException()
        {
            var mockMapper = new Mock<IMapper>();
            var mockContext = new Mock<DataContext>();
            var mockDbSet = new Mock<DbSet<ImmobilierEntity>>();

            // Mock the context and DbSet
            mockContext.Setup(x => x.Set<ImmobilierEntity>()).Returns(mockDbSet.Object);
            mockContext.Setup(x => x.SaveChangesAsync(CancellationToken.None)).ThrowsAsync(new Exception("Error"));

            // Mock the mapper
            mockMapper.Setup(x => x.Map<ImmobilierEntity>(It.IsAny<Entity.Immobilier>())).Returns(new ImmobilierEntity());
            mockMapper.Setup(x => x.Map<Entity.Immobilier>(It.IsAny<ImmobilierEntity>())).Returns(new Entity.Immobilier());

            // Create the service
            var service = new ImmobilierRepository(mockContext.Object, mockMapper.Object);

            // Define a test entity
            var entity = new Entity.Immobilier();

            //Act
            var response = await service.CreateAsync(entity);

            // Assert
            Assert.False(response.Success);
            Assert.Equal("Error", response.Message);
            Assert.Null(response.Data);

            // Verify database interactions
            mockDbSet.Verify(x => x.AddAsync(It.IsAny<ImmobilierEntity>(),CancellationToken.None), Times.Once);
            mockContext.Verify(x => x.SaveChangesAsync(CancellationToken.None), Times.Once);

            // Verify mapper interactions
            mockMapper.Verify(x => x.Map<ImmobilierEntity>(entity), Times.Once);
            mockMapper.Verify(x => x.Map<Entity.Immobilier>(It.IsAny<ImmobilierEntity>()), Times.Never);
        }

        [Fact]
        public async void GetByIdAsync_ReturnOneItemFromTheDatabase()
        {
            //Arrange
            _imapperMock.Setup(mapper => mapper.Map<Entity.Immobilier>(It.IsAny<ImmobilierEntity>()))
                .Returns(new Entity.Immobilier { Id = "12345" ,Avance="2 mois"});
            var expected = listImmobilierEntity[0];

            //Act
            var handler = new ImmobilierRepository(_contextMock.Object, _imapperMock.Object);
            var actual = await handler.GetByIdAsync("12345");
            
            //Assert
            Assert.True(actual != null);
            Assert.Equal(expected.Id, actual.Data?.Id);
            Assert.Equal(expected.Avance, actual.Data?.Avance);

        }

        [Fact]
        public async void GetByIdAsync_NoElement_ShouldReturnNullData()
        {
            //Arrange
            var expected = false;

            //Act
            var handler = new ImmobilierRepository(_contextMock.Object, _imapperMock.Object);
            var actual = await handler.GetByIdAsync("1234");

            //Assert
            Assert.True(actual != null);
            actual.Success.ShouldBe(expected);
            Assert.Equal(expected, actual.Success);
            

        }


        List<Entity.Immobilier> dataList = new List<Entity.Immobilier>
            {
                new Entity.Immobilier{Id="123450",DateDeCreation=new DateTime(),Avance="2 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=12000,Reff="13245"},
                new Entity.Immobilier{Id="1251230",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=20000,Reff="13212"}
            };

        private Task<ServiceResponse<Entity.Immobilier>> OutputItem()
        {
            var response = new ServiceResponse<Entity.Immobilier>();
            
            response.Success = true;
            response.Message = "OK";
            response.Data = dataList[0];
            return Task.FromResult(response);
        }

        private Task<ServiceResponse<List<Entity.Immobilier>>> OutputList()
        {
            var response = new ServiceResponse<List<Entity.Immobilier>>();

            response.Success = true;
            response.Message = "OK";
            response.Data = listImmobilier;
            return Task.FromResult(response);
        }



        List<ImmobilierEntity> listImmobilierEntity = new()
            {
                new ImmobilierEntity{Id="12345",DateDeCreation=new DateTime(),Avance="2 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=12000,Reff="11223"},
                new ImmobilierEntity{Id="12346",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=20000,Reff="11224"},
                new ImmobilierEntity{Id="12347",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 3 chambre salon douche et cuisine interne",Prix=21000,Reff="11225"}
            };

        List<Entity.Immobilier> listImmobilier = new()
            {
                new Entity.Immobilier{Id="12345",DateDeCreation=new DateTime(),Avance="2 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=12000,Reff="11223"},
                new Entity.Immobilier{Id="12346",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=20000,Reff="11224"},
                new Entity.Immobilier{Id="12347",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 3 chambre salon douche et cuisine interne",Prix=21000,Reff="11225"}
            };
    }
}
