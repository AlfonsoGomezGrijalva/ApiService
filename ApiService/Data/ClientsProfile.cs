using ApiService.Data.Entities;
using ApiService.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Data
{
    public class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            this.CreateMap<Client, ClientModel>()
                .ReverseMap();

            this.CreateMap<Address, AddressModel>()
                .ReverseMap();
        }
    }
}
