using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Animals;

namespace OOPNatureReserveSimulationSolution
{
    public class AnimalGenerator : IAnimalGenerator
    {
        public AnimalGenerator()
        {
        }
        public List<Animal> Generate()
        {
            AnimalFactory animalFactory = new AnimalFactory();

            List<Animal> animalsForSimulation = animalFactory.CreateAllAnimals();

            return animalsForSimulation;
        }
    }
}
