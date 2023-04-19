using Microsoft.AspNetCore.Mvc;
using ToDoTaskSolution.Entities;
using ToDoTaskSolution.Models;

namespace ToDoTaskSolution.Controllers
{
    public class ToDoTaskController : Controller
    {

        private readonly TODOTASKSContext context;

        public ToDoTaskController(TODOTASKSContext context)
        {
            this.context = context;
        }
    

        public IActionResult Index()
        {

            var methodTasks = context.Todotasks.Join(context.Assignments,
                          task => task.Id,
                          assignment => assignment.Id,
                        (task, assignment) => new Todotask
                        {
                            Id = task.Id,
                            Name = task.Name,
                            Date = task.Date,
                            Done = task.Done,
                            Description = task.Description,
                            AssignmentId = assignment.Id,
                            Assignment = assignment
                        }).ToList();

            context.SaveChanges();

            return View(methodTasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateNewTask(Todotask task)
        {
            Assignment newAssignment = new Assignment();
            newAssignment.CreatedBy = task.Assignment.CreatedBy;
            newAssignment.AssignedTo = task.Assignment.AssignedTo;

            Todotask newTask = new Todotask();
            newTask.Name = task.Name;
            newTask.Description = task.Description;
            newTask.Done = false;
            newTask.Date = task.Date;
            newTask.Assignment = newAssignment;

            context.Todotasks.Add(newTask);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var methodTask = context.Todotasks.Join(context.Assignments,
                        task => task.Id,
                        assignment => assignment.Id,
                      (task, assignment) => new Todotask
                      {
                          Id = task.Id,
                          Name = task.Name,
                          Date = task.Date,
                          Done = task.Done,
                          Description = task.Description,
                          AssignmentId = assignment.Id,
                          Assignment = assignment
                      }).FirstOrDefault(x => x.Id == id);

            return View(methodTask);
        }

        public IActionResult EditTask(Todotask editedTask)
        {

            Todotask task = context.Todotasks.FirstOrDefault(x => x.Id == editedTask.Id);

            task.Id = editedTask.Id;
            task.Name = editedTask.Name;
            task.Description = editedTask.Description;
            task.Done = editedTask.Done;

            Assignment assignment = context.Assignments.FirstOrDefault(x => x.Id == editedTask.Id);
            assignment.AssignedTo = editedTask.Assignment.AssignedTo;
            assignment.CreatedBy = editedTask.Assignment.CreatedBy;


            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id) 
        {
            var methodTask = context.Todotasks.Join(context.Assignments,
                        task => task.Id,
                        assignment => assignment.Id,
                      (task, assignment) => new Todotask
                      {
                          Id = task.Id,
                          Name = task.Name,
                          Date = task.Date,
                          Done = task.Done,
                          Description = task.Description,
                          AssignmentId = assignment.Id,
                          Assignment = assignment
                      }).FirstOrDefault(x=>x.Id==id);

            return View(methodTask); 
        }


        public IActionResult Delete(int id)
        {
            Todotask task = context.Todotasks.FirstOrDefault(x => x.Id == id);
            context.Todotasks.Remove(task);

            Assignment assignment = context.Assignments.FirstOrDefault(x => x.Id == task.AssignmentId);
            context.Assignments.Remove(assignment);

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
