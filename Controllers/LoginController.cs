using VoeAirlines.Services;
using VoeAirlines.ViewModels;
using Microsoft.AspNetCore.Mvc;


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
        return Ok(_loginService.ListarLogin());
    }
    
    [HttpGet]
    public IActionResult ListarLogin()
    {
        return Ok(_loginService.ListarLogin());
    }


}