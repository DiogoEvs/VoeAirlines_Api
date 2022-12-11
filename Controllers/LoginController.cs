using VoeAirlines.Services;
using VoeAirlines.ViewModels;
using Microsoft.AspNetCore.Mvc;
using VoeAirlines.Entities;


[Route("api/login")]
[ApiController]

public class LoginController:ControllerBase{

    private readonly LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]

    public IActionResult AdicionarLogin(AdicionarLoginViewModel dados)
    {
        var login = _loginService.AdicionarLogin(dados);
        return CreatedAtAction(nameof(ListarLoginPeloId), new { id = login.Id }, login);
    }
    
    [HttpGet]
    public IActionResult ListarLogin()
    {
        return Ok(_loginService.ListarLogin());
    }

    [HttpGet("{id}")]
    public IActionResult ListarLoginPeloId(int id)
    {
        var login = _loginService.ListarLoginPeloId(id);

        if(login != null)
        {
            return Ok(login);
        }

        return NotFound();
    }

        [HttpPut("{id}")]
    public IActionResult AtualizarLogin(int id, AtualizarLoginViewModel dados)
    {
        if (id != dados.Id)
            return BadRequest("O id informado na URL é diferente do id informado na requisição.");

        var login = _loginService.AtualizarLogin(dados);
        return Ok(login);
    }

    [HttpDelete("{id}")]
    public IActionResult ExcluirLogin(int id)
    {
        _loginService.ExcluirLogin(id);
        return NoContent();
    }

}