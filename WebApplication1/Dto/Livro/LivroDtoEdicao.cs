using WebApplication1.Dto.Vinculo;

namespace WebApplication1.Dto.Livro
{
    public class LivroDtoEdicao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        //o livro terá um autor
        public AutorVinculoDto Autor { get; set; }
    }
}
