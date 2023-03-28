﻿using L11_OOPEncapsulation.Animals;
using L11_OOPEncapsulation.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Lion : Carnivores
    {
        public Lion() : base(10, new HashSet<Food>() { new Milk() }, 10)
        {
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
