using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthDemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuthDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Acesso para qualquer usuário anônimo";

        [HttpGet("autenticated")]
        [Authorize]
        public string Authorized() => $"Usuário {User.Identity.Name} Autenticado";

        [HttpGet("legendary")]
        [Authorize(Roles = "Lendario")]
        public string Legendary() => "Pode fazer o que quiser meu querido, tu é o brabo.";

        [HttpGet("gold")]
        [Authorize(Roles = "Ouro")]
        public string Golds() => "Parabéns por ser um dos doze cavaleiros mais poderosos entre todos.";

        [HttpGet("silver")]
        [Authorize(Roles = "Prata")]
        public string Silvers() => "Bem vindo cavaleiro de Prata.";

        [HttpGet("shrine-pronouncement")]
        [Authorize(Roles = "Ouro,Prata")]
        public string ShrinePronouncement() => "O Grande Mestre tem um comunicado, direcione-se até o salão principal.";

        [HttpGet("spectrum")]
        [Authorize(Roles = "Espectro")]
        public string Spectrums() => $"Se erga novamente, {User.Identity.Name}, o imperador Hades o convoca.";
    }
}
