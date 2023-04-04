using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Carnivores : Animal
    {
        public Carnivores(string name, int energy, int maxEnergy, List<Food> diet, int matureAge) : base(name, energy, maxEnergy, diet, matureAge)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            AnimalFactory animalFactory = new AnimalFactory();
            return new List<Food> { new Milk(), new Meat(), animalFactory.CreateFrog(), animalFactory.CreateSalmon() };
        }

    }

}
