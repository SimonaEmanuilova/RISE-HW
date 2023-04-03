using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Carnivores : Animal
    {
        public Carnivores(string name, int maxEnergy, List<Food> diet, int matureAge) : base(name, maxEnergy, diet, matureAge)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            return new List<Food> { new Milk(), new Meat(), new Frog(), new Salmon()};
        }

    }

}
