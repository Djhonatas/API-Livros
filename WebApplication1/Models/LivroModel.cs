namespace WebApplication1.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        //o livro terá um autor
        public AutorModel Autor { get; set; }
    }
}
