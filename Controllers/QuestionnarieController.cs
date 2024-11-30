using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DB;
using IRepository;


namespace quizApp.Controllers
{
    public class QuestionnarieController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AplicationUser> _userManager;
        private readonly SignInManager<AplicationUser> _signInManager;
        private readonly IGroupQuestion<GroupQuestions> _repository;
        private const string SessionKey = "Questions";


        public QuestionnarieController(ILogger<HomeController> logger, UserManager<AplicationUser> userManager, SignInManager<AplicationUser> signInManager, IGroupQuestion<GroupQuestions> repository)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;

        }
        public IActionResult Index()
        {
            ViewData["UserRole"] = User.IsInRole("ADMIN") ? "ADMIN" : User.IsInRole("USER") ? "USER" : "GUEST";
            ViewData["UserName"] = User.Identity.IsAuthenticated ? User.Identity.Name : "Invitado";
            var questions = HttpContext.Session.Get<List<SaveQuestionDtos>>(SessionKey) ?? new List<SaveQuestionDtos>();
            ViewBag.QuestionList = questions;
            return View();
        }

        [HttpGet]
        public IActionResult GetQuestion(string questionText)
        {

            var questions = HttpContext.Session.Get<List<SaveQuestionDtos>>(SessionKey) ?? new List<SaveQuestionDtos>();


            var question = questions.FirstOrDefault(q => q.Question == questionText);

            if (question != null)
            {
                return Json(question);
            }

            return Json(new { error = "Pregunta no encontrada" });
        }


        [HttpPost]
        public IActionResult Question(SaveQuestionDtos questionR)
        {

            Console.WriteLine("Datos recibidos:");
            Console.WriteLine($"Pregunta: {questionR.Question}");
            Console.WriteLine($"Respuesta Correcta: {questionR.RigthAnswer}");
            Console.WriteLine($"Respuesta Incorrecta 1: {questionR.WrongAnswer}");
            Console.WriteLine($"Respuesta Incorrecta 2: {questionR.WrongAnswerTwo}");
            Console.WriteLine($"Respuesta Incorrecta 3: {questionR.WrongAnswerThree}");

            List<SaveQuestionDtos> questions;
            if (HttpContext.Session.GetString(SessionKey) == null)
            {
                //No existe nada en la session, creamos la coleccion
                questions = new List<SaveQuestionDtos>();
                Console.WriteLine("No esta validando bien los datos");
            }
            else
            {
                questions = HttpContext.Session.Get<List<SaveQuestionDtos>>(SessionKey);
            }
            questions.Add(questionR);
            Console.WriteLine("Cuantos datos hay " + questions.Count);
            HttpContext.Session.Set("Questions", questions);

            int count = questions?.Count ?? 0; // Si la lista es nula, el conteo será 0
            Console.WriteLine($"Cantidad de elementos en la sesión: {count}");

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(string questionText)
        {
            try
            {

                var questions = HttpContext.Session.Get<List<SaveQuestionDtos>>(SessionKey) ?? new List<SaveQuestionDtos>();

                if (questions.Count != 0)
                {

                    questions.RemoveAll(q => q.Question == questionText);
                    HttpContext.Session.Set(SessionKey, questions);
                    Console.WriteLine($"Pregunta eliminada: {questionText}");
                }
                else
                {
                    Console.WriteLine("No hay preguntas en la lista para eliminar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la pregunta: {ex.Message}");
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> CreateQuestionnarie(IFormCollection form)
        {
            try
            {
                var groupQuestionName = form["GroupQuestionName"];
                if (!int.TryParse(form["ResponseTimeInMinutes"], out var responseTime) || responseTime <= 0)
                {
                    TempData["Error"] = "El tiempo de respuesta debe ser un número válido mayor a 0.";
                    return RedirectToAction("Index");
                }
                var description = form["Description"];
                var isPublic = form["Access"] == "on";
                var image = form.Files["Image"];

                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Authorization", "Home");
                }

                if (string.IsNullOrEmpty(groupQuestionName))
                {
                    TempData["Error"] = "Debe completar los campos requeridos.";
                    return RedirectToAction("Index");
                }

                if (image != null && image.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(image.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(extension))
                    {
                        TempData["Error"] = "El archivo debe ser una imagen (.jpg, .jpeg, .png, .gif).";
                        return RedirectToAction("Index");
                    }

                    var filePath = Path.Combine("wwwroot/uploads", image.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                }

                // Simular guardar en base de datos



                var questionnaire = new
                {
                    Name = groupQuestionName,
                    Time = responseTime,
                    Description = description,
                    Access = isPublic,
                    ImageName = image?.FileName
                };

               /*  _repository.AddGroupQuestion();        */ 

                TempData["Success"] = "Cuestionario creado exitosamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Ocurrió un error al crear el cuestionario: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        private IActionResult Questions()
        {
            var questionList = HttpContext.Session.Get<List<SaveQuestionDtos>>(SessionKey);
            ViewBag.QuestionList = questionList;


            return View(questionList);
        }

        private void SaveQuestionsToSession(List<SaveQuestionDtos> questions)
        {
            HttpContext.Session.Set(SessionKey, questions);
        }


    }

}