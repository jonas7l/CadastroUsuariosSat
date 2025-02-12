using CadastroUsuarios.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CadastroUsuarios.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public AuthController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Cadastro() => View();
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(string nome, string senha, string confirmacaoSenha)
        {
            if (await _userManager.FindByNameAsync(nome) != null)
            {
                ModelState.AddModelError("Nome", "Usuário já existe.");
                return View("Cadastro");
            }

            if (senha != confirmacaoSenha)
            {
                ModelState.AddModelError("Senha", "As senhas não coincidem.");
                return View("Cadastro");
            }

            var usuario = new Usuario
            {
                UserName = nome,
                Nome = nome
            };

            var resultado = await _userManager.CreateAsync(usuario, senha);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var erro in resultado.Errors)
                {
                    ModelState.AddModelError("", erro.Description);
                }
                return View("Cadastro");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string nome, string senha)
        {
            var usuario = await _userManager.FindByNameAsync(nome);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuário ou senha inválidos.");
                return View("Login");
            }

            var resultado = await _signInManager.PasswordSignInAsync(usuario, senha, true, false);
            if (!resultado.Succeeded)
            {
                ModelState.AddModelError("", "Usuário ou senha inválidos.");
                return View("Login");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
