using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Herbivores : Animal
    {

        public Herbivores(string name, int maxEnergy, HashSet<Food> diet, int matureAge) : base(name, maxEnergy, diet, matureAge)
        {
        }

      

        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Seeds(), new TallPlant() };
        }
    }

}
