using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1.API.Request;
using _1.API.Response;
using _2.Domain;
using _3.Data;
using _3.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClientController : ControllerBase
    {
        private readonly IClientData _clientData;
        private readonly IClientDomain _clientDomain;
        private readonly IMapper _mapper;
        public ClientController(IClientData clientData, IClientDomain clientDomain, IMapper mapper)
        {
            _clientData = clientData;
            _clientDomain = clientDomain;
            _mapper = mapper;
        }
        // GET: api/Client
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _clientData.getAllClientAsync();
            var result = _mapper.Map<List<Client>, List<ClientResponse>>(data);
            return Ok(result);
        }

        // GET: api/Client/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _clientData.getByIdAsync(id);
            var result = _mapper.Map<Client, ClientResponse>(data);
            
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Client
        [HttpPost]
        public async Task<IActionResult> PostAsync ([FromBody] ClientRequest data)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var client = _mapper.Map<ClientRequest, Client>(data);
                var result = await _clientDomain.SaveClientAsync(client);
                return Created("api/client", result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClientRequest data)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var client = _mapper.Map<ClientRequest, Client>(data);
                var result = await _clientDomain.UpdateClientAsync(client, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            
            }
        }       

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientDomain.DeleteClientAsync(id);
            return Ok();
        }
        
         // GET: api/Client
        [HttpGet("Orders")]
        public async Task<IActionResult> GetOrderAsync()
        {
            var data = await _clientData.getAllOrderAsync();
            var result = _mapper.Map<List<Order>, List<OrderResponse>>(data);
            return Ok(result);
        }

        // GET: api/Client/5
        [HttpGet("Orders/{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var data = await _clientData.getByIdOrderAsync(id);
            var result = _mapper.Map<Order, OrderResponse>(data);
            
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Client
        [HttpPost ("Orders")]
        public async Task<IActionResult> PostOrderAsync ([FromBody] OrderRequest data)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var order = _mapper.Map<OrderRequest, Order>(data);
                var result = await _clientDomain.SaveOrderAsync(order);
                return Created("api/order", result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Client/5
        [HttpPut("Orders/{id}", Name = "PutOrders")]
        public async Task<IActionResult> PutOrder(int id, [FromBody] OrderRequest data)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var order = _mapper.Map<OrderRequest, Order>(data);
                var result = await _clientDomain.UpdateOrderAsync(order, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            
            }
        }

        // DELETE: api/Client/5
        [HttpDelete("Orders/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _clientDomain.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
