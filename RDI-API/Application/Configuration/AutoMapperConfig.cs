using Application.ViewModels;
using Domain.Entities;
using AutoMapper;

namespace Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CardViewModel, Card>().ReverseMap();
            CreateMap<CustomerCardViewModel, Card>().ReverseMap();
        }
    }
}
