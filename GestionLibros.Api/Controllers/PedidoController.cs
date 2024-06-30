using GestionLibros.Dto.Request;
using GestionLibros.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionLibros.Api.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }
        [HttpGet("{dni}")]
        public async Task<IActionResult> Get(string dni)
        {
            var response = await pedidoService.GetAsync(dni);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PedidoRequestDto pedidoRequestDto)
        {
            var response = await pedidoService.AddAsync(pedidoRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
