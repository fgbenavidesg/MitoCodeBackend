using GestionLibros.Dto.Request;
using GestionLibros.Services.Implementation;
using GestionLibros.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestionLibros.Api.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosService librosService;

        public LibrosController(ILibrosService  librosService)
        {
            this.librosService = librosService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await librosService.GetAsync();
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await librosService.GetLibroAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(LibroRequestDto libro)
        {
            var response = await librosService.AddAsync(libro);
            return response.Success ? Ok(response) : BadRequest(response);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, LibroRequestDto libro)
        {
            var response = await librosService.UpdateAsync(id, libro);
            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await librosService.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
