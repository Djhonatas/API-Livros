using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class AutorModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sobrenome{ get; set; }
        [JsonIgnore]
        //um autor pode ter vários livros, por isso eu crio uma propiredade ICollection
        public ICollection<LivroModel> Livros { get; set; }
    }
}
