using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Data;
using WebApplication1.Dto.Autor;
using WebApplication1.Models;

namespace WebApplication1.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly ApplicationDbContext _context;
        public AutorService(ApplicationDbContext context) 
        {
            _context = context;
        }

        //ROTA PARA BUSCAR AUTOR PELO ID
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                
                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado!";
                return resposta;
                    

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        //ROTA PARA BUSCAR AUTOR PELO ID DO LIVRO
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                
                if(livro == null)
                {
                    resposta.Mensagem = "Nenhum resgistro localizado";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        //ROTA PARA LISTAR TODOS AUTORES
        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            { 

                var autores = await _context.Autor.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram coletados!";

                return resposta;

            } 
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        //  ROTA PARA INSERIR NOVO AUTOR
        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDtoCriacao autorDtoCriacao)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>> ();

            try
            {
                var autor = new AutorModel()
                {
                    Name = autorDtoCriacao.Name,
                    Sobrenome = autorDtoCriacao.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorDtoEdicao autorDtoEdicao)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorDtoEdicao.Id);

                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado!";
                    return resposta;
                }

                autor.Name = autorDtoEdicao.Name;
                autor.Sobrenome = autorDtoEdicao.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autor
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado!";
                    return resposta;
                }
                //removo o autor do banco
                _context.Remove(autor);
                //salvo a alteração
                await _context.SaveChangesAsync();

                //retorno todos os autores numa lista
                resposta.Dados = await _context.Autor.ToListAsync();
                resposta.Mensagem = "Autor removido com sucesso!";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
