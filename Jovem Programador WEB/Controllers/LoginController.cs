using Jovem_Programador_WEB.Data.Repositorio.Interfaces;
using Jovem_Programador_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jovem_Programador_WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginRepositorio _LoginRepositorio;

        public LoginController(IConfiguration configuration, ILoginRepositorio loginRepositorio)
        {
            _configuration = configuration;   
            _LoginRepositorio = loginRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
         public IActionResult BuscarLogin(Login login)
        {
            try
            {
               var acesso = _LoginRepositorio.ValidarLogin(login);

                if (acesso != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MsgErro"] = "Usuário ou senha incorretos!";
                }
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao buscar dados do usuário";
            }
            return View("Index");
        }
    }
}
