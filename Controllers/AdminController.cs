using Microsoft.AspNetCore.Mvc;
namespace quizApp.Controllers;

public class AdminController: Controller
{

      private readonly ILogger<HomeController> _logger;

        public AdminController(ILogger<HomeController> logger)
        {
            _logger = logger;        
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index()
        {
           
            return View();
        }
        

     

        

}