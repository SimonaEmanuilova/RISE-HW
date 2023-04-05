using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals
{
    public class Lion : Carnivores
    {
        public Lion(int energy, int maxEnergy, IAnimalEvents animalEvents) : 
            base("Lion", energy, maxEnergy, new List<Food>() { new Milk() }, 5, animalEvents)
        {
        }

        public override void MakeSoundWhenEating()
        {
            Console.WriteLine("Rawwwwwr I will eat you!!!");
        }

        public override List<Food> GetMatureDiet()
        {
            AnimalGenerator animalGenerator = new AnimalGenerator(_events);

            return new List<Food> { new Milk(), new Meat(), animalGenerator.CreateFrog(), animalGenerator.CreateSalmon(), animalGenerator.CreateGazelle() };
        }

    }
}
