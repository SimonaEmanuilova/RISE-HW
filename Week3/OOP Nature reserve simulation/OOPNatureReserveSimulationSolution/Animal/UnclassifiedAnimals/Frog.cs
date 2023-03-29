using OOPNatureReserveSimulationSolution.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPNatureReserveSimulationSolution.Animals;



namespace OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals
{
    public class Frog : Animal
    {

        public Frog() : base("Frog", 10, new HashSet<Food>() { new Algae() }, 1)
        {
        }

        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Algae(), new Insects() };
        }



    }
}
