using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Biomes
{
    public class Savannah : Biome
    {
        public Savannah(IAnimalEvents events) : base("Savannah", events)
        {
        }

        public override List<Animal> SetAnimals()
        {
            AnimalGenerator animalGenerator = new AnimalGenerator(_events);

            this.Animals = new List<Animal> { animalGenerator.CreateGazelle(), animalGenerator.CreateLion() };

            return this.Animals;
        }

        public override List<Food> SetFoods()
        {
            this.Foods = new List<Food>(this.Animals) { new Meat(), new Milk(), new Seeds(), new TallPlant(), new Insects(), new Plant() };

            return this.Foods;
        }

        public override Biome CreateNewInstance()
        {
            Savannah savannah = new Savannah(_events);
            savannah.Animals = savannah.SetAnimals();
            savannah.Foods = savannah.SetFoods();
            foreach (Animal animal in savannah.Animals)
            {
                animal.SetCurrentBiome(savannah);
            }
            return savannah;
        }
    }

}
