using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals
{
    public class Lion : Carnivores
    {
        private const int matureAge = 5;

        public Lion(int energy, int maxEnergy, IAnimalEvents animalEvents) : 
            base("Lion", energy, maxEnergy, new List<Food>() { new Milk() }, matureAge, animalEvents)
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
