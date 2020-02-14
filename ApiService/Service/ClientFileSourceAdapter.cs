using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Data.Entities;

namespace ApiService.Service
{
    public class ClientFileSourceAdapter : IClientSourceAdapter
    {
        private string _filePath;
        private readonly ClientFileSource _clientFileSource;

        public ClientFileSourceAdapter(string filePath, ClientFileSource clientFileSource)
        {
            _filePath = filePath;
            _clientFileSource = clientFileSource;
        }

        public async Task<List<Client>> GetClients()
        {
            return await _clientFileSource.GetClientsFromFile(_filePath);
        }
    }
}
