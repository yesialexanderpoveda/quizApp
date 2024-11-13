using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using quizApp.Models;
using Microsoft.AspNetCore.Identity;
using DB;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Azure.Identity;

namespace quizApp.Controllers
{
    public class QuestionnarieController : Controller
    {
        private readonly ILogger<QuestionnarieController> _logger;
     

        public QuestionnarieController(ILogger<QuestionnarieController> logger)
        {
            _logger = logger;
    
        }

        // Acción Index: Gestión de roles y usuario autenticado
        public async Task<IActionResult> Index()
        {
            string userRole = "GUEST";
            string UserName = "Invitado";
            

         
            // Pasar la información a la vista
            ViewData["UserRole"] = userRole;
            ViewData["UserName"] = User.Identity.IsAuthenticated ? User.Identity.Name : "Invitado";
            return View();
        }
        
        }
}