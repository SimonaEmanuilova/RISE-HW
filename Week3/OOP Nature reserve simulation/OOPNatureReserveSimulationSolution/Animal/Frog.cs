using L11_OOPEncapsulation.Animals;
using L11_OOPEncapsulation.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Frog : Animal
    {

        public Frog() : base(10, new HashSet<Food>() { new Algae() }, 1)
        {
        }

        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Algae(), new Insects() };
        }

        public override void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"A frog is starving.");
        }

        public override void GetDyingAnimal()
        {
            Console.WriteLine("A frog has died.");
        }

        public override void MakeSoundWhenEating(Food food)
        {
            Console.WriteLine($"A frog is eating {food.Name}.");
        }
    }
}
