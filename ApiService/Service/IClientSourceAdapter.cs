using ApiService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Service
{
    public interface IClientSourceAdapter
    {
        Task<List<Client>> GetClients();
    }
}
