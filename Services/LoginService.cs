using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.ViewModels;
//Criar ViewModelos - você deve criar daqui a pouco

namespace VoeAirlines.Services;

public class LoginService
{

    private readonly VoeAirlinesContext _context;

    public LoginService(VoeAirlinesContext context)
    {

         _context = context;

    }

    public DetalhesrLoginViewModel AdicionarLogin (AdicionarLoginViewModel dados) {
        var login = new Login(dados.Usuario,dados.Senha,dados.DataCriacao);
        //Contexto -> banco
        _context.Add(login); //adicionar o objeto no cilco de vida do EF.
        _context.SaveChanges();//Salva as mudanças no contexto

        return new DetalhesLoginViewModel
    {
        login.Id,
        login.Usuario,
        login.DataCriacao

    };
    }

     public IEnumerable<ListarAeronaveViewModel> ListarLogin()
    {
        return _context.Logins.Select(l => new ListarLoginViewModel(l.Usuario, l.DataCriacao));
    }

}