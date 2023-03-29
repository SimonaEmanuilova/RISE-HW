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

        public Gazelle() : base(12, new HashSet<Food>() { new Milk() }, 8)
        {
        }


        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Milk(), new Seeds(), new TallPlant() };
        }

        public override void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"A gazelle is starving.");
        }

        public override void GetDyingAnimal()
        {
            Console.WriteLine("A gazelle has died.");
        }

        public override void MakeSoundWhenEating(Food food)
        {
            Console.WriteLine($"A gazelle is eating {food.Name}.");
        }


    }
}
