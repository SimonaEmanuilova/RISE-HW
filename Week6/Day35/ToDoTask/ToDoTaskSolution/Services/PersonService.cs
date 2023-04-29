using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoTaskSolution.Entities;

namespace ToDoTaskSolution.Services
{
    public class PersonService : IPersonService
    {
        private readonly TODOTASKSContext context;

        public PersonService(TODOTASKSContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Person> GetAllPeople()
        {
           List<Person> allPeople = context.People.ToList();
            
            context.SaveChanges();

            return allPeople ;
        }

        [HttpGet]
        public Person GetById(int id)
        {
            return context.People.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet]
        public Person GetByName(string name)
        {
            return context.People.FirstOrDefault(p => p.Name == name);
        }

        [HttpGet]
        public bool CreatePerson(Person newPerson)
        {
            context.People.Add(newPerson); 
            context.SaveChanges();

            return true;
        }

        [HttpPost]
        public bool EditPerson(Person personToEdit)
        {
            Person person = context.People.FirstOrDefault(x => x.Id == personToEdit.Id);

            person.Id = personToEdit.Id;
            person.Name = personToEdit.Name;
            person.Age = personToEdit.Age;

            context.SaveChanges();

            return true;
        }

        public bool DeletePerson(int id)
        {
            if (context.Todotasks.Any(x => x.Assignment.AssignedToId == id || x.Assignment.CreatedById==id))
                {
                Console.WriteLine("You cannot delete a user who has tasks");
                    return false;
            }
            else{  Person person = context.People.FirstOrDefault(x=> x.Id==id);
            context.People.Remove(person);
}
            context.SaveChanges();
            return true;
        }



    }
}
