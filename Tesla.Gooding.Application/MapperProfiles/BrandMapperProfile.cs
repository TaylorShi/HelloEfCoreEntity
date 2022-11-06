using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Gooding.DataContract.BrandModule.DTO;
using Tesla.Gooding.DataContract.BrandModule.VO;
using Tesla.Gooding.Domain.AggregatesModel.BrandAggregates;

namespace Tesla.Gooding.Application.MapperProfiles
{
    /// <summary>
    /// 品牌映射配置
    /// </summary>
    public class BrandMapperProfile : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BrandMapperProfile()
        {
            CreateMap<Brand, BrandDto>()
                .ForMember(d => d.BrandId, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.BrandCode, opt => opt.MapFrom(src => src.Code))
                .ForMember(d => d.BrandName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.BrandLogo, opt => opt.MapFrom(src => src.Logo))
                .ReverseMap();
            CreateMap<Brand, CreateBrandVo>()
                .ForMember(d => d.BrandCode, opt => opt.MapFrom(src => src.Code))
                .ForMember(d => d.BrandName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.BrandLogo, opt => opt.MapFrom(src => src.Logo))
                .ReverseMap();
        }
    }
}
