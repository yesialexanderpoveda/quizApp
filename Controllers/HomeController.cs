using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using quizApp.Models;
using Microsoft.AspNetCore.Identity;
using DB;
namespace quizApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AplicationUser> _userManager;


    public HomeController(ILogger<HomeController> logger, UserManager<AplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {

        string userRole = "GUEST";
        if (User.Identity.IsAuthenticated)
        {

            AplicationUser appUser = await _userManager.GetUserAsync(User);
            if (appUser != null)
            {
                  var roles = await _userManager.GetRolesAsync(appUser);
                 userRole = roles.Contains("ADMIN") ? "ADMIN" : "USER";
            }
        }
        ViewData["UserRole"] = userRole;
        ViewData["UserName"] = User.Identity.IsAuthenticated ? User.Identity.Name : "Invitado";
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
}
