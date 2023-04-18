using Microsoft.AspNetCore.Mvc;
using ToDoTaskSolution.Models;

namespace ToDoTaskSolution.Controllers
{
    public class ToDoTaskController : Controller
    {

        public static List<Assignment> _assignments = new List<Assignment>
        {
            new Assignment( 1, "Simona","David"),

            new Assignment( 2, "Dimi","Vladi")
        };

        public static List<ToDoTask> _toDoTasks = new List<ToDoTask> {

        new ToDoTask( 1, "Walk the cat", "I know you have cat allergy, but pleace walk the cat.",DateTime.Now),

        new ToDoTask( 2, "Shower the parrot", "Shower the parrot, otherwise he gets anxiety", DateTime.Now)
        };


        public IActionResult Index()
        {

            var methodTasks = _toDoTasks.Join(_assignments,
                          task => task.Id,
                          assignment => assignment.Id,
                        (task, assignment) => new ToDoTask
                        {
                            Id = task.Id,
                            Name = task.Name,
                            Date = task.Date,
                            Done = task.Done,
                            Description = task.Description,
                            AssignmentId = assignment.Id,
                            Assignment = assignment
                        }).ToList();


            return View(methodTasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateNewTask(ToDoTask task)
        {
            Assignment newAssignment = new Assignment();
            newAssignment.Id = _assignments.Count + 1;
            newAssignment.CreatedBy = task.Assignment.CreatedBy;
            newAssignment.AssignedTo = task.Assignment.AssignedTo;

            ToDoTask newTask = new ToDoTask();
            newTask.Id = _toDoTasks.Count + 1;
            newTask.Name = task.Name;
            newTask.Description = task.Description;
            newTask.Done = false;
            newTask.Date = task.Date;
            newTask.AssignmentId = newAssignment.Id;

            _assignments.Add(newAssignment);
            _toDoTasks.Add(newTask);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(_toDoTasks.FirstOrDefault(x => x.Id == id));
        }

        public IActionResult EditTask(ToDoTask editedTask)
        {
            ToDoTask task = _toDoTasks.FirstOrDefault(x => x.Id == editedTask.Id);

            task.Id = editedTask.Id;
            task.Name = editedTask.Name;
            task.Description = editedTask.Description;
            task.Done = editedTask.Done;

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id) { return View(_toDoTasks.FirstOrDefault(x => x.Id == id)); }


        public IActionResult Delete(int id)
        {
            ToDoTask task = _toDoTasks.FirstOrDefault(x => x.Id == id);
            _toDoTasks.Remove(task);

            return RedirectToAction("Index");
        }
    }
}
