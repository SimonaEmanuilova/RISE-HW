using ToDoTaskSolution.Entities;

namespace ToDoTaskSolution.Entities;

public class TaskPersonDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Done { get; set; }
    public int CreatedById { get; set; }
    public int AssignedToId { get; set; }
    public Assignment Assignment { get; set; }
    public List<Person> People { get; set; }


    public TaskPersonDTO()
    {
    }
}
