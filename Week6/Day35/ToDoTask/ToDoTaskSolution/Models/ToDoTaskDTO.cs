using ToDoTaskSolution.Entities;

namespace ToDoTaskSolution.Models
{
    public class ToDoTaskDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Done { get; set; }
        public Assignment Assignment { get; set; }

        public ToDoTaskDTO()
        {
        }
    }
}
