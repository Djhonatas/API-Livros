namespace WebApplication1.Models
{
    //<T> eu informo que essa classe vai retornar informações genéricas.
    public class ResponseModel<T>
    {
        //o tipo de dados será genérico também. Já a ? diz que o dado pode ser null
        public T? Dados {get; set;}
        public string Mensagem {get; set;} = string.Empty;
        public bool Status {get; set;} = true;
    }
}
