using Microsoft.AspNetCore.Mvc;
using ToDoTaskSolution.Entities;
using ToDoTaskSolution.Services;

namespace ToDoTaskSolution.Controllers
{
    public class ToDoTaskController : Controller
    {

        private readonly IToDoListService _listService;

        public ToDoTaskController(IToDoListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Todotask> tasks = new();

            tasks = _listService.GetAllTasks();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todotask task)
        {
            if (task == null) { return BadRequest("Error"); }

            Assignment newAssignment = new Assignment();
            newAssignment.CreatedBy = task.Assignment.CreatedBy;
            newAssignment.AssignedTo = task.Assignment.AssignedTo;

            Todotask newTask = new Todotask();
            newTask.Name = task.Name;
            newTask.Description = task.Description;
            newTask.Done = false;
            newTask.Date = task.Date;
            newTask.Assignment = newAssignment;

            _listService.CreateToDoTask(newTask);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
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
