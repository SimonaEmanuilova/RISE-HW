using ToDoTaskSolution.Entities;

namespace ToDoTaskSolution.Services
{
    public interface IToDoListService
    {
        public List<Todotask> GetAllTasks();
        public void CreateToDoTask(Todotask newTask);

        public (Todotask,bool) GetJoinedTaskWithAssignment(int id);

        public bool EditToDoTask(Todotask editedTask);

        public bool DeleteTask(int id);
    }
}
