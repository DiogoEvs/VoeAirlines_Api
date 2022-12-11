namespace VoeAirlines.ViewModels;
public class DetalhesLoginViewModel
{

 public DetalhesLoginViewModel(int id, string? usuario, DateTime dataCriacao)
    {
        Id= id;
        Usuario = usuario;
        DataCriacao = dataCriacao;
    }
    
    public int Id { get; set; }
    public string? Usuario { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    
}