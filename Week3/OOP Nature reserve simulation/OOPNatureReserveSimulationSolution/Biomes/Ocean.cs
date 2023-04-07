using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Biomes
{
    public class Ocean : Biome
    {
        public Ocean(IAnimalEvents events) : base("Ocean", events) 
        {
        }

        public override List<Animal> SetAnimals()
        {
            AnimalGenerator animalGenerator = new AnimalGenerator(_events);

            this.Animals = new List<Animal> { animalGenerator.CreateSalmon() };
            return this.Animals;
        }

        public override List<Food> SetFoods()
        {
            this.Foods = new List<Food>(this.Animals) { new Insects(), new Krill(), new Algae() };
            return this.Foods;
        }

        public override Biome CreateNewInstance()
        {
            Ocean ocean = new Ocean(_events);
            ocean.Animals = ocean.SetAnimals();
            ocean.Foods = ocean.SetFoods();
            foreach (Animal animal in ocean.Animals)
            {
                animal.SetCurrentBiomeForAnimal(ocean);
            }
            return ocean;
        }

    }


}
