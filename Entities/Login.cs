namespace VoeAirlines.Entities;
public class Login{

    public Login(string? usuario, string? senha, DateTime dataCriacao)
    {
        Usuario = usuario;
        Senha = senha;
        DataCriacao = dataCriacao;
    }

    public int Id { get; set; }
    public string? Usuario {get; set; }

    public string? Senha {get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;
}