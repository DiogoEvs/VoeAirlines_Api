namespace VoeAirlines.Entities;
public class Login{

    public int Id { get; set; }
    public string? Usuario {get; set; }

    public string? Senha {get; set; }

    public DateTime DataCriacao { get; set; }
}