using GestionLibros.Dto.Request;
using GestionLibros.Dto.Response;
using GestionLibros.Entities;
using GestionLibros.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestionLibros.Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService clientesService;

        public ClientesController(IClientesService clientesService)
        {
            this.clientesService = clientesService;
        }
        [HttpGet]
        public  async Task<IActionResult> Get()
        {
                var response = await clientesService.GetAsync();
                return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await clientesService.GetClienteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(ClienteRequestDto clientes)
        {
            var response = await clientesService.AddAsync(clientes);
            return response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ClienteRequestDto clientes)
        {
            var response = await clientesService.UpdateAsync(id, clientes);
            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await clientesService.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
