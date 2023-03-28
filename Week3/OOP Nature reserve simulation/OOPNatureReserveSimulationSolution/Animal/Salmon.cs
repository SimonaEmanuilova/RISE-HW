using L11_OOPEncapsulation.Animals;
using L11_OOPEncapsulation.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Salmon : Animal
    {
        public Salmon() : base(10, new HashSet<Food>() { new Insects() }, 2)
        {
        }

        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Algae(), new Insects() };
        }
        public override void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"A salmon is starving.");
        }

        public override void GetDyingAnimal()
        {
            Console.WriteLine("A salmon has died.");
        }

        public override void MakeSoundWhenEating(Food food)
        {
            Console.WriteLine($"A salmon is eating {food.Name}.");
        }
    }
}
