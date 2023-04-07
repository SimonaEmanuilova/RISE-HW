using OOPNatureReserveSimulationSolution.Biomes;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public interface IAnimalEvents
    {
        public bool Enabled { get; set; }

        void Eat(string animalName, string? foodName, int? foodNutritionalValue);
        void Mature(string animalName);
        void Starve(string animalName);
        void Die(string animalName);
        void Move(string animalName, Biome? oldBiome, Biome? newBiome);
    }

}
