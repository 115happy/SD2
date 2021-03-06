﻿using AutoMapper;
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
                cfg.CreateMap<DiseaseTypeDto, DiseaseType>();

                cfg.CreateMap<Disease, DiseaseDto>();
                cfg.CreateMap<DiseaseDto, Disease>();

                cfg.CreateMap<DiseaseCase, DiseaseCaseDto>();
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

                cfg.CreateMap<Clinic, ClinicDto>();
                cfg.CreateMap<ClinicDto, Clinic>();

                cfg.CreateMap<Instrument, InstrumentDto>();
                cfg.CreateMap<InstrumentDto, Instrument>();

                cfg.CreateMap<Text, TextDto>();
                cfg.CreateMap<TextDto, Text>();

                cfg.CreateMap<Picture, PictureDto>();
                cfg.CreateMap<PictureDto, Picture>();

                cfg.CreateMap<Video, VideoDto>();
                cfg.CreateMap<VideoDto, Video>();

                cfg.CreateMap<RPRecordDto, RPRecord>();
                cfg.CreateMap<RPRecord, RPRecordDto>();

                cfg.CreateMap<UserIntactDto, User>();
                cfg.CreateMap<User, UserIntactDto>();

                cfg.CreateMap<DiseaseCaseTabDto, DiseaseCaseTab>();
                cfg.CreateMap<DiseaseCaseTab, DiseaseCaseTabDto>();
            });
        }
    }
}