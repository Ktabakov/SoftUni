using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SuplierInputDto, Supplier>();
            CreateMap<PartsInputDto, Part>();
            CreateMap<CarsInputDto, Car>();
            CreateMap<CustomerInputDto, Customer>();
            CreateMap<SalesInputDto, Sale>();
        }
    }
}
