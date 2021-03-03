using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using netzkern.MyBookstore.Model;
using netzkern.MyBookstore.UI.Web.Mvc.ViewModels;

namespace netzkern.MyBookstore.UI.Web.Mvc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, HomeViewModel>()
                .ForMember(dto => dto.BestsellerBook, opt => opt.MapFrom(src => src));

            Mapper.CreateMap<IEnumerable<Product>, HomeViewModel>()
                .ForMember(dto => dto.RelatedBookSet, opt => opt.MapFrom(src => src.ToList()));
        }
    }
}