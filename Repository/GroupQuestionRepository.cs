using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB;
using Microsoft.EntityFrameworkCore;


namespace IRepository
{

    public class GroupQuestionRepository : IGroupQuestion<GroupQuestions>
    {

        private readonly DbContext _context;

        public GroupQuestionRepository(DbContext context)
        {
            _context = context;
        }

        public async Task AddGroupQuestionAsync(GroupQuestions group, List<Questions> questions)
        {
            try
            {
                Console.WriteLine("Creando grupo de preguntas...");

                _context.Set<GroupQuestions>().Add(group);
                await _context.SaveChangesAsync();

                Console.WriteLine($"El ID generado del grupo es: {group.GroupQuestionId}");
               
                if (questions != null && questions.Count > 0)
                {
                    foreach (var question in questions)
                    {
                        question.GroupQuestionId = group.GroupQuestionId; 
                        _context.Set<Questions>().Add(question);
                    }

                    await _context.SaveChangesAsync();
                }

                Console.WriteLine("Grupo y preguntas guardados exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el grupo y las preguntas: {ex.Message}");
                throw;
            }
        }


        // Actualizar un grupo de preguntas
        public void UpdateGroupQuestion(int id)
        {
            var groupQuestion = _context.Set<GroupQuestions>().Find(id);
            if (groupQuestion != null)
            {
                // Realiza los cambios que necesites en el objeto
                groupQuestion.GroupQuestionName += " (Actualizado)"; // Ejemplo
                _context.SaveChanges();
            }
        }

        // Eliminar un grupo de preguntas
        public void RemoveGroupQuestion(int id)
        {
            var groupQuestion = _context.Set<GroupQuestions>().Find(id);
            if (groupQuestion != null)
            {
                _context.Set<GroupQuestions>().Remove(groupQuestion);
                _context.SaveChanges();
            }
        }

        // Obtener un grupo de preguntas por ID
        public List<GroupQuestions> GetGroupQuestion(int id)
        {
            return _context.Set<GroupQuestions>()
                .Include(g => g.Questions)
                .Where(g => g.GroupQuestionId == id)
                .ToList();
        }

        // Obtener todos los grupos de preguntas asociados a un usuario
        public List<GroupQuestions> GetGroupQuestionsByUser()
        {
            // Aquí puedes filtrar según un campo de usuario si existe
            return _context.Set<GroupQuestions>()
                .Include(g => g.Questions)
                .Where(g => g.Access == true) // Ejemplo de filtro
                .ToList();
        }

        // Obtener todos los grupos de preguntas públicos
        public List<GroupQuestions> GetGroupQuestionPublics()
        {
            return _context.Set<GroupQuestions>()
                .Include(g => g.Questions)
                .Where(g => g.Access) // Accesibles públicamente
                .ToList();
        }

        // Agregar una pregunta a un grupo existente
        public void AddQuestion()
        {

        }

        // Actualizar una pregunta por ID
        public void UpdateQuestion(int id)
        {
            var question = _context.Set<Questions>().Find(id);
            if (question != null)
            {
                // Realiza los cambios necesarios
                question.Question += " (Actualizada)"; // Ejemplo
                _context.SaveChanges();
            }
        }

        // Eliminar una pregunta por ID
        public void RemoveQuestion(int id)
        {
            var question = _context.Set<Questions>().Find(id);
            if (question != null)
            {
                _context.Set<Questions>().Remove(question);
                _context.SaveChanges();
            }
        }

        // Obtener una pregunta por ID
        public void GetQuestion(int id)
        {
            var question = _context.Set<Questions>()
                .FirstOrDefault(q => q.QuestionsId == id);

            if (question != null)
            {
                // Puedes retornar la pregunta o trabajar con ella según la lógica
                // Por ahora, es solo un ejemplo
                Console.WriteLine(question.Question);
            }
        }
    }

}