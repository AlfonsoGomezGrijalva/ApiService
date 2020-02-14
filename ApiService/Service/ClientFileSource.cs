using ApiService.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Service
{
    public class ClientFileSource
    {
        public async Task<List<Client>> GetClientsFromFile(string filename)
        {
            var clients = JsonConvert.DeserializeObject<List<Client>>(await File.ReadAllTextAsync(filename));

            return clients;
        }
    }
}
