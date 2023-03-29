using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Carnivores : Animal
    {
        //public Carnivores() : base(10, new HashSet<Food>() { new Milk() }, 10)
        //{
        //}

        public Carnivores(int maxEnergy, HashSet<Food> diet, int matureAge) : base(maxEnergy, diet, matureAge)
        {
        }

        public override void MakeSoundWhenEating(Food food)
        {
            Console.WriteLine($"A wild Carnivore is eating {food.Name}.");
        }

        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Milk(), new Meat() };
        }

        public override void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"Carnivore is starving.");
        }

        public override void GetDyingAnimal()
        {
            Console.WriteLine("A wild Carnivore has died.");
        }
    }

}
