using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Carnivores : Animal
    {
        //public Carnivores() : base(10, new HashSet<Food>() { new Milk() }, 10)
        //{
        //}

        public Carnivores(string name, int maxEnergy, HashSet<Food> diet, int matureAge) : base(name, maxEnergy, diet, matureAge)
        {
        }

        public override void ChangeDietForCarnivores()
        {
            List<HashSet<object>> hashSets = new List<HashSet<object>>();

            hashSets.Add(new HashSet<object>() { new Milk(), new Meat() });
            hashSets.Add(new HashSet<object>() { new Lion(), new Gazelle() });
        }

        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Milk(), new Meat(), new Gazelle(), new Frog(), new Salmon()};
        }

    }

}
