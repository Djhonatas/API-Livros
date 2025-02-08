using WebApplication1.Dto.Vinculo;

namespace WebApplication1.Dto.Livro
{
    public class LivroDtoCriacao
    {
        public string Titulo { get; set; }
        //o livro terá um autor
        public AutorVinculoDto Autor { get; set; }
    }
}
