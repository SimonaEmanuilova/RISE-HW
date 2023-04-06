using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Carnivores : Animal
    {
        public Carnivores(string name, int energy, int maxEnergy, List<Food> diet, int matureAge, IAnimalEvents animalEvents) : base(name, energy, maxEnergy, diet, matureAge, animalEvents)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            AnimalGenerator animalGenerator = new AnimalGenerator(_events);

            return new List<Food> { new Milk(), new Meat(), animalGenerator.CreateFrog(), animalGenerator.CreateSalmon() };
        }

    }

}
