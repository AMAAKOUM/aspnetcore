using Microsoft.AspNetCore.Mvc;
using SecondCoreWebApplication.Models;


namespace SecondCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // on cree une variable reference pour IStudentRepository
        private readonly IStudenRepository? _repository = null;

        // initialisation de la variable crée
        public HomeController(IStudenRepository repository)
        {
            _repository = repository;
        }
        public JsonResult Index()
        {
            List<Student>? allStudentDetails = _repository?.GetAllStudent();
            return Json(allStudentDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            Student? studentDetails = _repository?.GetStudentById(Id);
            return Json(studentDetails);
        }
    }
}
