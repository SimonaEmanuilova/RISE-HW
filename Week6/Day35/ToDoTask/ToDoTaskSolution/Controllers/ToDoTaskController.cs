using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoTaskSolution.Entities;
using ToDoTaskSolution.Services;

namespace ToDoTaskSolution.Controllers
{
    public class ToDoTaskController : Controller
    {

        private readonly IToDoListService _listService;
        private readonly IPersonService _personService;


        public ToDoTaskController(IToDoListService listService, IPersonService personService)
        {
            _listService = listService;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Todotask> tasks = new();

            tasks = _listService.GetAllTasks();

            if (!tasks.Any())
            {
                TempData["ErrorNoTasks"] = "There are no tasks to preview.";
                return View(tasks);
            }
            TempData.Remove("ErrorNoTasks"); 

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.People=_personService.GetAllPeople();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todotask task)
        {
            if (task == null) { return BadRequest("Error"); }

            Assignment newAssignment = new Assignment();
            newAssignment.CreatedById = task.Assignment.CreatedById;
            newAssignment.AssignedToId = task.Assignment.AssignedToId;

            Todotask newTask = new Todotask();
            newTask.Name = task.Name;
            newTask.Description = task.Description;
            newTask.Done = false;
            newTask.Date = task.Date;
            newTask.Assignment = new Assignment()
            {
                CreatedById = newAssignment.CreatedById,
                AssignedToId = newAssignment.AssignedToId
            };

            if (newTask.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "The date should be later than now");
            }

            if (!ModelState.IsValid) {

                ViewBag.People = _personService.GetAllPeople();

                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(task);
            }

            ModelState.Clear();

            _listService.CreateToDoTask(newTask);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.People = _personService.GetAllPeople();

            (Todotask todotask, bool isTrue) = _listService.GetJoinedTaskWithAssignment(id);

            if (!isTrue)
            {
                return BadRequest("Null content");
            }

            return View(todotask);
        }

        [HttpPost]
        public IActionResult Edit(Todotask editedTask)
        {
            if (editedTask.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "The date should be later than now");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.People = _personService.GetAllPeople();

                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(editedTask);
            }

            bool isTrue = _listService.EditToDoTask(editedTask);

            if (!isTrue)
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            (Todotask todotask, bool isTrue) = _listService.GetJoinedTaskWithAssignment(id);

            if (!isTrue)
            {
                return BadRequest("There is no To Do Task with such ID.");
            }

            return View(todotask);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool isTrue = _listService.DeleteTask(id);

            if (!isTrue)
            {
                return BadRequest("Null content");
            };

            return RedirectToAction("Index");
        }
    }
}
