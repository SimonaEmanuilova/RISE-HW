using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals
{
    public class Lion : Carnivores
    {
        public Lion() : base("Lion", 10, new List<Food>() { new Milk() }, 5)
        {
        }
      
        public override void MakeSoundWhenEating()
        {
            Console.WriteLine("Rawwwwwr I will eat you!!!");
        }

        public override List<Food> GetMatureDiet()
        {
            return new List<Food> { new Milk(), new Meat(), new Frog(), new Salmon(), new Gazelle() };
        }

    }
}
