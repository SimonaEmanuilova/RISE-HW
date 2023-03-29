using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals
{
    public class Lion : Carnivores
    {
        public Lion() : base("Lion", 10, new List<Food>() { new Milk() }, 5)
        {
        }
        public override List<Food> GetMatureDiet()
        {
            return base.GetMatureDiet();
        }

        public override void MakeSoundWhenEating()
        {
            Console.WriteLine("Rawwwwwr I will eat you!!!");
        }

    }
}
