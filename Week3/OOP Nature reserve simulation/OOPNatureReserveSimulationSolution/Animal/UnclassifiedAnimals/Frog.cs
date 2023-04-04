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

        public Frog(int energy, int maxEnergy) : base("Frog", energy, maxEnergy, new List<Food>() { new Algae() }, 1)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            return new List<Food> { new Algae(), new Insects() };
        }

        public override void MakeSoundWhenEating()
        {
            Console.WriteLine("Croak croak, my tummy is thankful.");
        }

    }
}
