using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Herbivores : Animal
    {

        public Herbivores(int maxEnergy, HashSet<Food> diet, int matureAge) : base(maxEnergy, diet, matureAge)
        {
        }

        public override void MakeSoundWhenEating(Food food)
        {
            Console.WriteLine($"A wild Herbivore animal is eating {food.Name}.");
        }


        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Seeds(), new TallPlant() };
        }

        public override void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"A wild Herbivore animal is starving.");
        }


        public override void GetDyingAnimal()
        {
            Console.WriteLine("A wild Herbivore animal has died.");
        }
    }

}
