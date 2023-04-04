using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals
{
    public class Lion : Carnivores
    {
        public Lion(int energy, int maxEnergy) : base("Lion", energy, maxEnergy, new List<Food>() { new Milk() }, 5)
        {
        }

        public override void MakeSoundWhenEating()
        {
            Console.WriteLine("Rawwwwwr I will eat you!!!");
        }

        public override List<Food> GetMatureDiet()
        {
            AnimalFactory animalFactory = new AnimalFactory();
            return new List<Food> { new Milk(), new Meat(), animalFactory.CreateFrog(), animalFactory.CreateSalmon(), animalFactory.CreateGazelle() };
        }

    }
}
