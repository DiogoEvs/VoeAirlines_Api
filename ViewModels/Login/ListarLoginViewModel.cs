namespace VoeAirlines.ViewModels;
public class ListarrLoginViewModel
{

 public ListarsLoginViewModel(string usuario, string senha, DateTime dataCriacao)
    {
        Usuario = usuario;
        DataCriacao = dataCriacao;
    }
    
    
    public string? Usuario { get; set; }

   

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    

   
}