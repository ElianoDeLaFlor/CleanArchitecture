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

namespace CleanArchitecture.Test.Immobilier
{
    public class DataAccess
    {
        //"MethodName_Condition_ExpectedResult"
        [Fact]
        public async void GetAllAsync__ReturnList()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Configure AutoMapper
                var mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<EnityMapperProfile>(); // Add your AutoMapper profile
                });

                var mapper = mapperConfiguration.CreateMapper();
                mock.Container.InjectProperties<IMapper>(mapper);

                // Configure DbContext
                var dbContextOptions = new DbContextOptionsBuilder<DbContext>()
                    .UseSqlServer("")
                    .Options;

                var dbContext = new DbContext(dbContextOptions); // Instantiate your DbContext
                mock.Container.InjectProperties<DbContext>(dbContext);


                mock.Mock<IImmobilierRepository>()
                    .Setup(x => x.GetAllAsync())
                    .Returns(OutputList());

                var repos= mock.Create<ImmobilierRepository>();
                var expected = await OutputList();
                var actual = await repos.GetAllAsync();

                Assert.True(actual!=null);
                Assert.Equal(expected.Data.Count, actual.Data.Count);
            }
            
        }

        private Task<ServiceResponse<List<Entity.Immobilier>>> OutputList()
        {
            List<Entity.Immobilier> result = new List<Entity.Immobilier>
            {
                new Entity.Immobilier{Id="12345",DateDeCreation=new DateTime(),Avance="2 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=12000,Reff="13245"},
                new Entity.Immobilier{Id="125123",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=20000,Reff="13212"}
            };
            var response = new ServiceResponse<List<Entity.Immobilier>>();
            
            response.Success = true;
            response.Message = "OK";
            response.Data = result;
            return Task.FromResult(response);
        }
    }
}
