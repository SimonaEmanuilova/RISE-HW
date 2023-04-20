using Microsoft.AspNetCore.Mvc;
using ToDoTaskSolution.Entities;
using ToDoTaskSolution.Models;

namespace ToDoTaskSolution.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly TODOTASKSContext context;

        public ToDoListService(TODOTASKSContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Todotask> GetAllTasks()
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

            return methodTasks;
        }

        [HttpGet]
        public void CreateToDoTask(Todotask newTask)
        {
            context.Todotasks.Add(newTask);
            context.SaveChanges();
        }

        [HttpGet]
        public (Todotask, bool) GetJoinedTaskWithAssignment(int id)
        {
            var todotask = context.Todotasks.Join(context.Assignments,
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

            if (todotask == null)
            {
                return (todotask, false);
            }

            return (todotask, true);
        }

        [HttpPost]
        public bool EditToDoTask(Todotask editedTask)
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

            return true;
        }

        [HttpDelete]
        public bool DeleteTask(int id)
        {

            Todotask task = context.Todotasks.FirstOrDefault(x => x.Id == id);
            context.Todotasks.Remove(task);

            Assignment assignment = context.Assignments.FirstOrDefault(x => x.Id == task.AssignmentId);
            context.Assignments.Remove(assignment);

            context.SaveChanges();
            return true;
        }

    }
}
