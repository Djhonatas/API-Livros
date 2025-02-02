using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto.Livro;
using WebApplication1.Models;

namespace WebApplication1.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly ApplicationDbContext _context;
        public LivroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
               
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = "Livro encontrado com sucesso!";
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<LivroModel>> BuscarLivroProIdAutor(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDtoCriacao livroDtoCriacao)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroDtoCriacao livroDtoEdicao)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {

                var livros = await _context.Livros.ToListAsync();
                
                if (livros == null)
                {
                    resposta.Mensagem = "Nenhum livro registrado!";
                }

                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram coletados!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
