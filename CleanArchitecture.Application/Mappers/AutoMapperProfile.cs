using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ImmobilierDto,Immobilier >()
                .AfterMap(
                    (dest, src) => {
                        src.Id = Helper.Code(28);
                        src.DateDeCreation= DateTime.Now;
                        src.DateDeModification = src.DateDeCreation;
                    }
                );
        }
    }
}
