using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dto.Livro;
using WebApplication1.Models;
using WebApplication1.Services.Livro;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;

        }

        [HttpGet("ListarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivro()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livros = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livros);
        }
    }
}
