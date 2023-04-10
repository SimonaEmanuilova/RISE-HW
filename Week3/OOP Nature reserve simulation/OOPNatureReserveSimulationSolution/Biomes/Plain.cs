using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Biomes
{
    public class Plain : Biome
    {
        public Plain(IAnimalEvents events) : base("Plain", events)
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
            this.Foods = new List<Food>(this.Animals) { new Seeds(), new TallPlant(), new Insects(), new Plant() };

            return this.Foods;
        }

        public override Biome CreateNewInstance()
        {
            Plain plain = new Plain(_events);
            plain.Animals = plain.SetAnimals();
            plain.Foods = plain.SetFoods();
            foreach (Animal animal in plain.Animals)
            {
                animal.SetCurrentBiome(plain);
            }
            return plain;
        }
    }
}
