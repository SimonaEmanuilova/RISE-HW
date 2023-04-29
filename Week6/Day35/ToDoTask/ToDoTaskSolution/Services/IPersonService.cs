using ToDoTaskSolution.Entities;

namespace ToDoTaskSolution.Services
{
    public interface IPersonService
    {
        public List<Person> GetAllPeople();

        public Person GetById(int id);

        public Person GetByName(string name);

        public bool CreatePerson(Person newPerson);

        public bool EditPerson(Person personToEdit);

        public bool DeletePerson(int id);
    }
}
