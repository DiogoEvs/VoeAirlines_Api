namespace VoeAirlines.ViewModels;

public class AtualizarLoginViewModel
{
    public AtualizarLoginViewModel(int id,string? usuario, string? senha,DateTime dataCriacao)
    {
        Id= id;
        Usuario = usuario;
        Senha = senha;
        DataCriacao = dataCriacao;
        
    }

    public int Id { get; set; }
    public string? Usuario { get; set; }
    public string? Senha  { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}