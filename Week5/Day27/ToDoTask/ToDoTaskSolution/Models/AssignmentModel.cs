namespace ToDoTaskSolution.Models
{
    public class AssignmentModel
    {

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedTo { get; set; }
        public virtual List<Task> Tasks { get; set; }

        public AssignmentModel(int assignmentId, string createdBy, string assignedTo)
        {
            Id = assignmentId;
            CreatedBy = createdBy;
            AssignedTo = assignedTo;
        }

        public AssignmentModel()
        {
        }
    }
}
