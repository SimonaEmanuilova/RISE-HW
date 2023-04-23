using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ToDoTaskSolution.Entities;
using ToDoTaskSolution.Models;
using ToDoTaskSolution.Services;

namespace ToDoTaskSolution.Controllers
{
    [Route("api")]
    [ApiController]
    public class ToDoTaskAPIController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;

        public ToDoTaskAPIController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpGet]
        [Route("get/toDoTask{id}")]
        public IActionResult GetTask(int id)
        {
            return Ok(_toDoListService.GetJoinedTaskWithAssignment(id).Item1);
        }

        [HttpGet]
        [Route("get/allTasks")]
        public IActionResult GetAllTasks()
        {
            return Ok(_toDoListService.GetAllTasks());
        }

        [HttpPost]
        [Route("createTask")]
        public IActionResult CreateTask(ToDoTaskDTO task)
        {
            Todotask newTask = new Todotask();

            newTask.Name = task.Name;
            newTask.Description = task.Description;
            newTask.Date = task.Date;
            newTask.Done = task.Done;
            newTask.Assignment = new Assignment()
            {
                CreatedBy = task.Assignment.CreatedBy,
                AssignedTo = task.Assignment.AssignedTo
            };

            bool isCreated = _toDoListService.CreateToDoTask(newTask);

            if (!isCreated)
            {
                return BadRequest();
            }

            return Created("~api/success", task);
        }

        [HttpPut]
        [Route("editTask")]
        public IActionResult EditTask(Todotask taskToEdit)
        {
            bool isEdited = _toDoListService.EditToDoTask(taskToEdit);

            if (!isEdited)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("deleteTask/{id}")]
        public IActionResult DeleteTask(int id)
        {
            bool isDeleted = _toDoListService.DeleteTask(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }




    }
}
