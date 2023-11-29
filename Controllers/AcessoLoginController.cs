using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RHMVC.Models;

namespace RHMVC.Controllers
{
    public class AcessoLoginController : Controller
    {
        private readonly Contexto _contexto;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AcessoLoginController(Contexto contexto)
        {
            _contexto = contexto;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChecarLogin(string usuario, string senha)
        {
            // Crie uma instância da classe Login e defina os parâmetros
            var login = new VerificaLogin(_contexto )
            {
                Usuario = usuario,
                Senha = senha,
            };

            // Realize a autenticação
            if (login.Acesso())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Autenticação falhou, retorne para a página de login com uma mensagem de erro
                ViewBag.MensagemErro = "Usuário ou senha inválidos";
                return View("Index","AcessoLogin");
            }
        }
    }
}
