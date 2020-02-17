using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Models;
using ApiService.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IConfiguration configuration, IMapper mapper, ILogger<ClientController> logger)
        {
            _configuration = configuration;
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
                IClientSourceAdapter clientSourceAdapter = new ClientFileSourceAdapter(_configuration.GetSection("JsonPath").Value, new ClientFileSource());

                var clients = await clientSourceAdapter.GetClients();

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