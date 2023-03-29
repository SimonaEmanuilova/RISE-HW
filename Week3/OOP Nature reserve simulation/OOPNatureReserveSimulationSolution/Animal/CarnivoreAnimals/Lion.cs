using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals
{
    public class Lion : Carnivores
    {
        public Lion() : base(15, new HashSet<Food>() { new Milk() }, 6)
        {
        }

        public override HashSet<Food> GetMatureDiet()
        {
            return base.GetMatureDiet();
        }

        public override void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"A lion is starving.");
        }

        public override void GetDyingAnimal()
        {
            Console.WriteLine("A lion has died.");
        }

        public override void MakeSoundWhenEating(Food food)
        {
            Console.WriteLine($"A lion is eating {food.Name}.");
        }
    }
}
