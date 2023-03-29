using OOPNatureReserveSimulationSolution.Animals;
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
        public Salmon() : base("Salmon", 10, new HashSet<Food>() { new Insects() }, 2)
        {
        }

        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Algae(), new Insects() };
        }
    }
}
