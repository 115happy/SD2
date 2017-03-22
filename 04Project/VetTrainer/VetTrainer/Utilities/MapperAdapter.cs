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

                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>();

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();

                cfg.CreateMap<Analysis, AnalysisDto>();
                cfg.CreateMap<AnalysisDto, Analysis>();

                cfg.CreateMap<Drug, DrugDto>();
                cfg.CreateMap<DrugDto, Drug>();

                cfg.CreateMap<Charge, ChargeDto>();
                cfg.CreateMap<ChargeDto, Charge>();
            });
        }
    }
}