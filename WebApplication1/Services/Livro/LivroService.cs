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
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

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

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum resgistro localizado";
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

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDtoCriacao livroDtoCriacao)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroDtoCriacao.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor localizado!";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroDtoCriacao.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroDtoEdicao livroDtoEdicao)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroDtoEdicao.Id);

                var autor = await _context.Autor
                    .FirstOrDefaultAsync(a => a.Id == livroDtoEdicao.Autor.Id);

                if (autor == null || livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                livro.Titulo = livroDtoEdicao.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado!";
                    return resposta;
                }
                //removo o autor do banco
                _context.Remove(livro);
                //salvo a alteração
                await _context.SaveChangesAsync();

                //retorno todos os autores numa lista
                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro removido com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {

                var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();

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
