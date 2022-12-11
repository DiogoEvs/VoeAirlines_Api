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

    public DetalhesLoginViewModel AdicionarLogin(AdicionarLoginViewModel dados)
    {
        var login = new Login(dados.Usuario, dados.Senha, dados.DataCriacao);
        //Contexto -> banco
        _context.Add(login); //adicionar o objeto no cilco de vida do EF.
        _context.SaveChanges();//Salva as mudanças no contexto

        return new DetalhesLoginViewModel
            (
        login.Id,
        login.Usuario,
        login.DataCriacao

            );
    }

    public IEnumerable<ListarLoginViewModel> ListarLogin()
    {
        return _context.Logins.Select(l => new ListarLoginViewModel(l.Id, l.Usuario, l.DataCriacao));
    }

    public DetalhesLoginViewModel? ListarLogin(int id)
    {
        var login = _context.Logins.Find(id);

        if (login != null)
        {
            return new DetalhesLoginViewModel
            (
                login.Id,
                login.Usuario,
                login.DataCriacao
            );
        }

        return null;
    }

    public DetalheComSenhaLoginViewModel? AtualizarLogin(AtualizarLoginViewModel dados)
    {

        var login = _context.Logins.Find(dados.Id);

        if (login != null)
        {
            login.Id = dados.Id;
            login.Usuario = dados.Usuario;
            login.Senha = dados.Senha;
            login.DataCriacao = dados.DataCriacao;

            _context.Update(login);
            _context.SaveChanges();

            return new DetalheComSenhaLoginViewModel(login.Id, login.Usuario, login.Senha,login.DataCriacao);
        }

        return null;
    }

    public void ExcluirLogin(int id)
    {

        var login = _context.Logins.Find(id);

        if (login != null)
        {
            _context.Remove(login);
            _context.SaveChanges();
        }
    }
}