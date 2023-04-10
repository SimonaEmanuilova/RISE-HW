using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Biomes;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Carnivores : Animal
    {
        public Carnivores(string name, int energy, int maxEnergy, List<Food> diet, List<Biome> possibleBiomes, int matureAge, IAnimalEvents animalEvents) : 
            base(name, energy, maxEnergy, diet, possibleBiomes, matureAge, animalEvents)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            AnimalGenerator animalGenerator = new AnimalGenerator(_events);

            return new List<Food> { new Milk(), new Meat(), animalGenerator.CreateFrog(), animalGenerator.CreateSalmon() };
        }

    }

}
