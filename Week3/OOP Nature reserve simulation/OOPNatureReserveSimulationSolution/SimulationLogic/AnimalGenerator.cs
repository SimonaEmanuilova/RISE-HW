using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Animals;

namespace OOPNatureReserveSimulationSolution
{
    public class AnimalGenerator : IAnimalGenerator
    {
        private readonly IAnimalEvents animalEvents;

        public AnimalGenerator(IAnimalEvents animalEvents)
        {
            this.animalEvents = animalEvents;
        }

        public Lion CreateLion()
        {
            int lionCurrentEnergy = 10;
            int lionMaxEnergy = 10;

            return new Lion(lionCurrentEnergy, lionMaxEnergy, animalEvents);
        }

        public Gazelle CreateGazelle()
        {
            int GazelleCurrentEnergy = 15;
            int GazelleMaxEnergy = 15;

            return new Gazelle(GazelleCurrentEnergy, GazelleMaxEnergy, animalEvents);
        }

        public Frog CreateFrog()
        {
            int FrogCurrentEnergy = 8;
            int FrogMaxEnergy = 8;
            return new Frog(FrogCurrentEnergy, FrogMaxEnergy, animalEvents);
        }

        public Salmon CreateSalmon()
        {
            int SalmonCurrentEnergy = 8;
            int SalmonMaxEnergy = 8;

            return new Salmon(SalmonCurrentEnergy, SalmonMaxEnergy, animalEvents);
        }

        public List<Animal> Generate()
        {

            List<Animal> allAnimals = new List<Animal>();

            Console.WriteLine("Choose number of Lions ");
            int numberOfLions = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLions; i++)
            {
                allAnimals.Add(CreateLion());
            }

            Console.WriteLine("Choose number of Gazelles ");
            int numberOfGazelles = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfGazelles; i++)
            {
                allAnimals.Add(CreateGazelle());
            }

            Console.WriteLine("Choose number of Frogs ");
            int numberOfFrogs = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfFrogs; i++)
            {
                allAnimals.Add(CreateFrog());
            }

            Console.WriteLine("Choose number of Salmons ");
            int numberOfSalmons = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfSalmons; i++)
            {
                allAnimals.Add(CreateSalmon());
            }

            return allAnimals;
        }
    }
}
