using WebApplication1.Dto.Autor;
using WebApplication1.Models;

namespace WebApplication1.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDtoCriacao autorDtoCriacao);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorDtoEdicao autorDtoEdicao);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);

    }
}
