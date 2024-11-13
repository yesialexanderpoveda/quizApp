using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using quizApp.Models;
using Microsoft.AspNetCore.Identity;
using DB;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Azure.Identity;

namespace quizApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AplicationUser> _userManager;
        private readonly SignInManager<AplicationUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AplicationUser> userManager, SignInManager<AplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Acción Index: Gestión de roles y usuario autenticado
        public async Task<IActionResult> Index()
        {
            string userRole = "GUEST";
            string UserName = "Invitado";

            // Verificar si el usuario está autenticado
            if (User.Identity.IsAuthenticated)
            {
                AplicationUser appUser = await _userManager.GetUserAsync(User);
                if (appUser != null)
                {
                    var roles = await _userManager.GetRolesAsync(appUser);
                    userRole = roles.Contains("ADMIN") ? "ADMIN" : "USER";
                    UserName = appUser.UserName;
                }
            }

            // Pasar la información a la vista
            ViewData["UserRole"] = userRole;
            ViewData["UserName"] = User.Identity.IsAuthenticated ? User.Identity.Name : "Invitado";
            return View();
        }

        // Acción para Registrar un nuevo usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AplicationUser { UserName = model.Name, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "USER");
                    // Iniciar sesión inmediatamente después de crear la cuenta
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    Console.WriteLine("registro exitoso");
                    return RedirectToAction("Index"); // Redirigir al Index
                }
                Console.WriteLine("Register error");
                Console.WriteLine(result);
                // Agregar los errores al ModelState si la creación falla
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View("Index"); // Volver a la vista Index en caso de error
        }

        // Acción para Iniciar sesión de un usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el usuario existe
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "No se encontró un usuario con este correo.");
                    return View("Index");
                }

                // Intentar iniciar sesión
                var result = await _signInManager.PasswordSignInAsync(
                    user,
                    model.Password,
                    isPersistent: false,
                    lockoutOnFailure: false
                );

                Console.WriteLine($"Email: {model.Email}, Password: {model.Password}");

                if (result.Succeeded)
                {
                    Console.WriteLine("Login exitoso");
                    return RedirectToAction("Index", "Home"); // Redirigir correctamente
                }
                else
                {
                    Console.WriteLine("Login error");
                    Console.WriteLine($"IsLockedOut: {result.IsLockedOut}");
                    Console.WriteLine($"IsNotAllowed: {result.IsNotAllowed}");
                    Console.WriteLine($"RequiresTwoFactor: {result.RequiresTwoFactor}");

                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "La cuenta está bloqueada. Inténtalo más tarde.");
                    }
                    else if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty, "No tienes permitido iniciar sesión.");
                    }
                    else if (result.RequiresTwoFactor)
                    {
                        ModelState.AddModelError(string.Empty, "Se requiere autenticación de dos factores.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Inicio de sesión no válido.");
                    }
                }
            }

            return View("Index");
        }


        // Acción para Cerrar sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {

            Console.WriteLine("ping logout");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


      

        // Acción para la página de privacidad (puedes personalizarla más)
        public IActionResult Privacy()
        {
            return View();
        }

        // Acción para manejar errores globales
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
