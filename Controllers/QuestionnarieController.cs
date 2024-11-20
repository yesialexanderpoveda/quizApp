using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using quizApp.Models;
using Microsoft.AspNetCore.Identity;
using DB;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Azure.Identity;
using IRepository;
using Repository;

namespace quizApp.Controllers
{
    public class QuestionnarieController : Controller
    {
        private readonly ILogger<QuestionnarieController> _logger;

        private ITemporalQuestions<SaveQuestionDtos> _questions;
        public QuestionnarieController(ILogger<QuestionnarieController> logger, ITemporalQuestions<SaveQuestionDtos> questions)
        {
            _logger = logger;
            _questions = questions;

        }

        // Acción Index: Gestión de roles y usuario autenticado
        public async Task<IActionResult> Index()
        {


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {

            ViewBag.questionList = _questions;
            return View("Questions");
        }


        [HttpPost]
        public async Task<IActionResult> Question(QuestionnarieViewModel questionR)
        {
            Console.WriteLine("################################################");
             
            if (!ModelState.IsValid)
            {
                Console.WriteLine("error en el modelo");
                // Si el modelo no es válido, regresa la misma vista con los errores de validación
                return View(questionR);
            }
            Console.WriteLine("Controlador Question");
            // Almacenar temporalmente la pregunta en la lista (o usar la lógica que tengas definida)
            _questions.Add(new SaveQuestionDtos
            {
                Question = questionR.Question,
                RigthAnswer = questionR.RigthAnswer,
                WrongAnswer = questionR.WrongAnswer,
                WrongAnswerTwo = questionR.WrongAnswerTwo,
                WrongAnswerThree = questionR.WrongAnswerThree
            });

            /*   TempData["Message"] = "Pregunta agregada exitosamente."; */
            return View();
        }

    }
}