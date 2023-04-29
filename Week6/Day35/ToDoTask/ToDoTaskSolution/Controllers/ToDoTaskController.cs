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

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TaskPersonDTO { People=_personService.GetAllPeople()});
        }

        [HttpPost]
        public IActionResult Create(TaskPersonDTO task)
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

            TaskPersonDTO taskDTO = new TaskPersonDTO();

            taskDTO.Id = todotask.Id;
            taskDTO.Name= todotask.Name;
            taskDTO.Description= todotask.Description;
            taskDTO.Date= todotask.Date;
            taskDTO.Done = todotask.Done;
            taskDTO.Assignment = todotask.Assignment;
            taskDTO.Assignment.Id = todotask.Assignment.Id;
            taskDTO.AssignedToId = todotask.Assignment.AssignedToId;
            taskDTO.CreatedById= todotask.Assignment.CreatedById;
            taskDTO.People = _personService.GetAllPeople();

            Assignment assignment =new Assignment();
            assignment.Id = todotask.AssignmentId;
            assignment.AssignedToId= todotask.Assignment.AssignedToId;
            assignment.CreatedById= todotask.Assignment.CreatedById;   

            return View(taskDTO);
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
