﻿using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals
{
    public class Salmon : Animal
    {
        public Salmon(int energy, int maxEnergy, IAnimalEvents animalEvents) : base("Salmon", energy, maxEnergy, new List<Food>() { new Insects() }, 2, animalEvents)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            return new List<Food> { new Algae(), new Insects() };
        }

        public override void MakeSoundWhenEating()
        {
            Console.WriteLine("...fish eating in silence ...");
        }
    }
}
