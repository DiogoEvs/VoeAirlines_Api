namespace VoeAirlines.ViewModels;
public class DetalhesLoginViewModel
{

 public DetalhesLoginViewModel(string usuario, string senha, DateTime dataCriacao)
    {
        Usuario = usuario;
        
        DataCriacao = dataCriacao;
    }
    
    public int Id { get; set; }
    public string? Usuario { get; set; }

    

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    

public DetalhesLoginViewModel AdicionarLogin (AdicionarLoginViewModel dados)
{
    var login = new DetalhesLoginViewModel (dados.Usuario,dados.Senha,dados.DataCriacao);

    _context.Add(login);// adicionar o objeto no ciclo de vida do EF.
    _context.SaveChanges();//Salva as mudanças no contexto

    return new DetalhesLoginViewModel
    {
        login.Id,
        login.Usuario,
        login.Senha,
        login.DataCriacao

    };
}
   
}