using System;
using AutoMapper;
using DevEK.Api.ViewModels;
using DevEK.Business.Models;

namespace DevEK.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Vendor, VendorDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();

        }

    }
}
