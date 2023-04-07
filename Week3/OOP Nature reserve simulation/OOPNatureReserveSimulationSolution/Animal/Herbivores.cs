using OOPNatureReserveSimulationSolution.Biomes;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Herbivores : Animal
    {
        public Herbivores(string name, int energy, int maxEnergy, List<Food> diet, List<Biome> possibleBiomes, int matureAge, IAnimalEvents animalEvents) : 
            base(name, energy, maxEnergy, diet, possibleBiomes, matureAge, animalEvents)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            return new List<Food> { new Seeds(), new TallPlant() };
        }
    }

}
