using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var methodTasks = context.Todotasks
                .Include(task => task.Assignment)
                    .ThenInclude(assignment => assignment.CreatedBy)
                .Include(task => task.Assignment)
                .Select(task => new Todotask()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Date = task.Date,
                    Done = task.Done,
                    Description = task.Description,
                    AssignmentId = task.AssignmentId,
                    Assignment = new Assignment()
                    {
                        Id = task.Assignment.Id,
                        CreatedBy = new Person()
                        {
                            Id = task.Assignment.CreatedBy.Id,
                            Name = task.Assignment.CreatedBy.Name,
                            Age = task.Assignment.CreatedBy.Age
                        },
                        AssignedTo = new Person()
                        {
                            Id = task.Assignment.AssignedTo.Id,
                            Name = task.Assignment.AssignedTo.Name,
                            Age = task.Assignment.AssignedTo.Age
                        }
                    }
                })
                .ToList();

            context.SaveChanges();

            return methodTasks;
        }

        [HttpGet]
        public bool CreateToDoTask(Todotask newTask)
        {
            context.Todotasks.Add(newTask);

            context.SaveChanges();

            return true;
        }

        [HttpGet]
        public (Todotask, bool) GetJoinedTaskWithAssignment(int id)
        {
            var todotask = context.Todotasks
                 .Include(task => task.Assignment)
                     .ThenInclude(assignment => assignment.CreatedBy)
                 .Include(task => task.Assignment)
                     .ThenInclude(assignment => assignment.AssignedTo)
                 .Select(task => new Todotask()
                 {
                     Id = task.Id,
                     Name = task.Name,
                     Date = task.Date,
                     Done = task.Done,
                     Description = task.Description,
                     AssignmentId = task.AssignmentId,
                     Assignment = new Assignment()
                     {
                         Id = task.Assignment.Id,
                         CreatedBy = new Person()
                         {
                             Id = task.Assignment.CreatedBy.Id,
                             Name = task.Assignment.CreatedBy.Name,
                             Age = task.Assignment.CreatedBy.Age
                         },
                         AssignedTo = new Person()
                         {
                             Id = task.Assignment.AssignedTo.Id,
                             Name = task.Assignment.AssignedTo.Name,
                             Age = task.Assignment.AssignedTo.Age
                         }
                     }
                 })
                 .FirstOrDefault(x => x.Id == id);

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

            Assignment assignment = context.Assignments.FirstOrDefault(x => x.Id == task.AssignmentId);
            assignment.AssignedToId = editedTask.Assignment.AssignedToId;
            assignment.CreatedById = editedTask.Assignment.CreatedById;

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
