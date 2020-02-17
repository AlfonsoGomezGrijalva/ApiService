using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Models;
using ApiService.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientSourceAdapter _clientSourceAdapter;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientSourceAdapter clientSourceAdapter, IMapper mapper, ILogger<ClientController> logger)
        {
            _clientSourceAdapter = clientSourceAdapter;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet()]
        public async Task<ActionResult<string>> Get()
        {
            return "value";
        }

        [HttpPost()]
        public async Task<ActionResult<List<ClientModel>>> Post()
        {
            try
            {
                var clients = await _clientSourceAdapter.GetClients();

                if (clients == null)
                    return NotFound();

                return _mapper.Map<List<ClientModel>>(clients);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving clients: {ex.ToString()}");
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}