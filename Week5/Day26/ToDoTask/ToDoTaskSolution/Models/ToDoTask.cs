﻿namespace ToDoTaskSolution.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Done { get; set; }
        public Assignment Assignment { get; set; }
        public  int AssignmentId { get; set; }

        public ToDoTask(int id, string name, string description, DateTime date)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Done = false;
        }

        public ToDoTask()
        {
        }
    }
}