using AutoMapper;
using BrandApp.MVC.Models;
using BrandApp.Services.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandApp.MVC.App_Start
{
    public class MapperConfig
    {
        public static void Setup()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Brand, LandingPageViewModel>()
                   .ForMember(desti => desti.BrandName, opt => opt.MapFrom(src => src.Name))
                   .ForMember(desti => desti.BrandDescription, opt => opt.MapFrom(src => src.Description))
                   .ForMember(desti => desti.BrandImgUrl, opt => opt.MapFrom(src => src.BrandImgUrl))
                   .ForMember(d => d.BrandId, opt => opt.MapFrom(src => src.Id));

                    cfg.CreateMap<Brand, HomePageViewModel>()
                      .ForMember(desti => desti.BrandName, opt => opt.MapFrom(src => src.Name))
                      .ForMember(desti => desti.BrandDescription, opt => opt.MapFrom(src => src.Description))
                      .ForMember(desti => desti.IsPreferred, opt => opt.MapFrom(src => false))
                      .ForMember(d => d.BrandId , opt => opt.MapFrom(src => src.Id));

                    cfg.CreateMap<Brand, BrandPageViewModel>()
                      .ForMember(desti => desti.BrandName, opt => opt.MapFrom(src => src.Name))
                      .ForMember(desti => desti.BrandDescription, opt => opt.MapFrom(src => src.Description))
                      .ForMember(d => d.BrandId, opt => opt.MapFrom(src => src.Id));

                    cfg.CreateMap<Promotion, PromotionPageViewModel>()
                    .ForMember(d => d.PromotionId, opt => opt.MapFrom(src => src.Id));

                    cfg.CreateMap<UserViewModel, User>()
                     .ForMember(desti => desti.Password, opt => opt.MapFrom(src => src.Password))
                     .ForMember(desti => desti.UserName, opt => opt.MapFrom(src => src.UserName));


                });
        }
    }
}