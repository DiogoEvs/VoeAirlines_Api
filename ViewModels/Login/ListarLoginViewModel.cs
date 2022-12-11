namespace VoeAirlines.ViewModels;
public class ListarLoginViewModel
{

 public ListarLoginViewModel(int id , string? usuario, DateTime dataCriacao)
    {
        Id = id;
        Usuario = usuario;
        DataCriacao = dataCriacao;
    }
    public int Id { get; set; }
    public string? Usuario { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;

}