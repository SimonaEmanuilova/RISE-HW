using OOPNatureReserveSimulationSolution.Animals;

namespace OOPNatureReserveSimulationSolution.Biomes
{
    public class BiomeGenerator
    {
        private readonly IAnimalEvents animalEvents;

        public BiomeGenerator(IAnimalEvents events)
        {
            this.animalEvents = events;
        }

        public List<Biome> Generate()
        {
            List<Biome> allPossibleBiomes = new List<Biome>() { new Savannah(animalEvents), new Ocean(animalEvents), new Plain(animalEvents) };
            foreach (var biome in allPossibleBiomes)
            {
                biome.SetAnimals();
                biome.SetFoods();
            }
            return allPossibleBiomes;
        }
        public Biome MakeRandomBiome(List<Biome> allPossibleBiomes)
        {
            Random random = new Random();
            Biome randomBiome = allPossibleBiomes.ElementAt(random.Next(allPossibleBiomes.Count));

            return randomBiome.CreateNewInstance();
        }


    }
}
