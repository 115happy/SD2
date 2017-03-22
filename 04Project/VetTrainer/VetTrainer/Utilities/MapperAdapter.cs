using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetTrainer.Models;
using VetTrainer.Models.DataTransferObjs;

namespace VetTrainer.Utilities
{
    public static class ClassMapperConfig
    {
        public static void SetupMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DiseaseType, DiseaseTypeDto>();
                cfg.CreateMap<Disease, DiseaseDto>();
                cfg.CreateMap<DiseaseCase, DiseaseCaseDto>();
                cfg.CreateMap<DiseaseTypeDto, DiseaseType>();
                cfg.CreateMap<DiseaseDto, Disease>();
                cfg.CreateMap<DiseaseCaseDto, DiseaseCase>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
            });
        }
    }
}