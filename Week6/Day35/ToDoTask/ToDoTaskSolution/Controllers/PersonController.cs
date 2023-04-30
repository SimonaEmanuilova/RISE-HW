using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoTaskSolution.Entities;
using ToDoTaskSolution.Services;

namespace ToDoTaskSolution.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Person> people = new();

            people = _personService.GetAllPeople();

            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (person == null) { return BadRequest("Error"); }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(person);
            }

            Person newPerson= new Person();
            newPerson.Id = person.Id;
            newPerson.Name = person.Name;
            newPerson.Age= person.Age;

            _personService.CreatePerson(newPerson);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Person person = _personService.GetAllPeople().FirstOrDefault(x => x.Id == id);

            if (person==null)
            {
                return BadRequest("There is no Person with such ID.");
            }

            return View(person);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Person person = _personService.GetAllPeople().FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return BadRequest("There is no Person with such ID.");
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(person);
            }

            bool isTrue = _personService.EditPerson(person);

            if (!isTrue)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool isTrue = _personService.DeletePerson(id);

            if (!isTrue)
                {
                    TempData["ErrorMessage"] = "The user is taking part in tasks, you cannot delete him yet!";
                    return RedirectToAction("Index");
                }

            TempData.Remove("ErrorMessage");

            return RedirectToAction("Index");
        }
    }
}
