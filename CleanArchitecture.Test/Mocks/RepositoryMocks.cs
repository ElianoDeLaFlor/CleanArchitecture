using Microsoft.EntityFrameworkCore.ChangeTracking;

using Entity= CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CleanArchitecture.Persistence.Interfaces;
using Autofac.Extras.Moq;
using CleanArchitecture.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Test.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IImmobilierRepository> GetImmobilier_ById(string id)
        {
            //using (var mock = AutoMock.GetLoose())
            //{
            //    mock.Mock<IImmobilierRepository>()
            //        .Setup(x => x.GetByIdAsync(""))
            //        .Returns(GetImmobilierById(id));
            //}
                

            var mockImmobilierRepository = new Mock<IImmobilierRepository>();
            mockImmobilierRepository
                .Setup(repo=>repo.GetByIdAsync(id))
                .Returns(GetImmobilierById(id));

            return mockImmobilierRepository;
        }

        public static Mock<IImmobilierRepository> AddImmobillier(Entity.Immobilier immobilier)
        {
            var mockrepo= new Mock<IImmobilierRepository>();
            mockrepo.Setup(x => x.CreateAsync(It.IsAny<Entity.Immobilier>()))
                .Returns(CreateImmobilier(immobilier));

            return mockrepo;
        }

        public static Mock<IImmobilierRepository> AddImmobillierWithError(Entity.Immobilier immobilier)
        {
            var mockrepo = new Mock<IImmobilierRepository>();
            mockrepo.Setup(x => x.CreateAsync(It.IsAny<Entity.Immobilier>()))
                .Returns(CreateErrorImmobilier(immobilier));

            return mockrepo;
        }

        public static Mock<IImmobilierRepository> GetAllImmobillier()
        {
            var mockrepo = new Mock<IImmobilierRepository>();
            mockrepo.Setup(x => x.GetAllAsync())
                .Returns(GetImmobilierList());

            return mockrepo;
        }

        static List<Entity.Immobilier> listImmobilier = new List<Entity.Immobilier>
            {
                new Entity.Immobilier{Id="12345",DateDeCreation=new DateTime(),Avance="2 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=12000,Reff="11223"},
                new Entity.Immobilier{Id="12346",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=20000,Reff="11224"},
                new Entity.Immobilier{Id="12347",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 3 chambre salon douche et cuisine interne",Prix=21000,Reff="11225"}
            };

        

        private static Task<ServiceResponse<List<Entity.Immobilier>>> GetImmobilierList()
        {
            var response = new ServiceResponse<List<Entity.Immobilier>>();

            response.Success = true;
            response.Message = "OK";
            response.Data = dataList;
            return Task.FromResult(response);
        }

        public static readonly List<Entity.Immobilier> dataList = new()
        {
                new Entity.Immobilier{Id="12345",DateDeCreation=new DateTime(),Avance="2 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=12000,Reff="11223"},
                new Entity.Immobilier{Id="12346",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=20000,Reff="11224"},
                new Entity.Immobilier{Id="12347",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 3 chambre salon douche et cuisine interne",Prix=21000,Reff="11225"}
            };

        private static Task<ServiceResponse<Entity.Immobilier>> GetImmobilierById(string id)
        {
            var response = new ServiceResponse<Entity.Immobilier>();

            var immobilier=(from item in dataList where item.Id == id select item).Single();

            response.Success = true;
            response.Message = "OK";
            response.Data = immobilier;
            return Task.FromResult(response);
        }

        private static Task<ServiceResponse<Entity.Immobilier>> CreateImmobilier(Entity.Immobilier immobilier)
        {
            var response = new ServiceResponse<Entity.Immobilier>();

            dataList.Add(immobilier);

            response.Success = true;
            response.Message = "OK";
            response.Data = immobilier;
            return Task.FromResult(response);
        }

        private static Task<ServiceResponse<Entity.Immobilier>> CreateErrorImmobilier(Entity.Immobilier immobilier)
        {
            var response = new ServiceResponse<Entity.Immobilier>();

            response.Success = true;
            response.Message = "OK";
            response.Data = immobilier;
            return Task.FromResult(response);
        }

        private static readonly List<ImmobilierEntity> listImmobilierEntity = new()
            {
                new ImmobilierEntity{Id="12345",DateDeCreation=new DateTime(),Avance="2 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=12000,Reff="11223"},
                new ImmobilierEntity{Id="12346",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 2 chambre salon douche et cuisine interne",Prix=20000,Reff="11224"},
                new ImmobilierEntity{Id="12347",DateDeCreation=new DateTime(),Avance="1 mois", Description="appartement de 2 chambre salon", FullDescription="appartement de 3 chambre salon douche et cuisine interne",Prix=21000,Reff="11225"}
            };
    }
}
