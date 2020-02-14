using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Models;
using ApiService.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientSourceAdapter _clientSourceAdapter;
        private readonly IMapper _mapper;

        public ClientController(IClientSourceAdapter clientSourceAdapter, IMapper mapper)
        {
            _clientSourceAdapter = clientSourceAdapter;
            _mapper = mapper;
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}