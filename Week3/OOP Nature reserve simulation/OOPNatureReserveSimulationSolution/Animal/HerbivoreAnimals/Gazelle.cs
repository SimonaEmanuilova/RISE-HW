using OOPNatureReserveSimulationSolution.Biomes;
using OOPNatureReserveSimulationSolution.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals
{
    public class Gazelle : Herbivores
    {
        private const int matureAge = 4;

        public Gazelle(int energy, int maxEnergy, IAnimalEvents animalEvents) :
            base("Gazelle",
                energy, maxEnergy,
                new List<Food>() { new Milk(), new Plant() },
                new List<Biome> { new Savannah(animalEvents), new Plain(animalEvents) },
                matureAge,
                animalEvents)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            return new List<Food> { new Milk(), new Seeds(), new TallPlant(), new Plant() };
        }

        public override void MakeSoundWhenEating()
        {
            Console.WriteLine("Mmmm, it's nice being a vegan...");
        }
    }
}
