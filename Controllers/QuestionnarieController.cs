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
              

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Question() 
        {

             return View();
        }
        
        }
}