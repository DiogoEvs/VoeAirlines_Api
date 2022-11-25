namespace VoeAirlines.ViewModels;
public class ListarLoginViewModel
{

 public ListarLoginViewModel(string? usuario,  DateTime dataCriacao)
    {
        
        Usuario = usuario;
        
        DataCriacao = dataCriacao;
    }
    
    public string? Usuario { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;

}