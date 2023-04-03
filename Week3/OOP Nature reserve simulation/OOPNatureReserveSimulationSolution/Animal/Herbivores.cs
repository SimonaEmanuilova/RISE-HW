using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class Herbivores : Animal
    {
        public Herbivores(string name, int maxEnergy, List<Food> diet, int matureAge) : base(name, maxEnergy, diet, matureAge)
        {
        }

        public override List<Food> GetMatureDiet()
        {
            return new List<Food> { new Seeds(), new TallPlant() };
        }
    }

}
