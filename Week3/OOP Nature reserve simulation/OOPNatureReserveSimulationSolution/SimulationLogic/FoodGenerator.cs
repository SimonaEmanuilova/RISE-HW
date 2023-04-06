using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class FoodGenerator : IFoodGenerator
    {
        public List<Food> Generate(List<Animal> allAnimals)
        {
            List<Food> allFoods = new List<Food>(allAnimals) {
                new Meat(), new Milk(), new Seeds(), new TallPlant(),
                new Algae(), new Insects(), new Krill(), new Plant() };

            return allFoods;
        }


    }
}
