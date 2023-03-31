using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using OOPNatureReserveSimulationSolution.SimulationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class FoodGenerator :IFoodGenerator
    {
        public List<Food> Generate(List<Animal> allAnimals)
        {
            List<Food> allFoods = new List<Food>(allAnimals) {
                new Meat(), new Milk(), new Seeds(), new TallPlant(),
                new ToxicMushroom(), new Algae(), new Insects(), new Krill(), new Plant() };

            return allFoods;
        }

       
    }
}
