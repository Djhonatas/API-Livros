using WebApplication1.Dto.Livro;
using WebApplication1.Models;

namespace WebApplication1.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idAutor);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idLivro);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDtoCriacao livroDtoCriacao);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroDtoEdicao livroDtoEdicao);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}
