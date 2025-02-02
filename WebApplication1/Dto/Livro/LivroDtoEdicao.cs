using WebApplication1.Models;

namespace WebApplication1.Dto.Livro
{
    public class LivroDtoEdicao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        //o livro terá um autor
        public AutorModel Autor { get; set; }
    }
}
