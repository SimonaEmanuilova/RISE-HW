using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Simulation
    {
        public void Run(List<Animal> allAnimals, List<Food> allFoods, Statistics statistics)
        {
            int dayCounter = 0;

            bool hasAlive = true;

            while (hasAlive)
            {
                dayCounter++;

                hasAlive = false;

                FeedAnimals(allFoods, allAnimals);
                CallForPlantsRegeneration(allFoods);

                hasAlive = CheckIsAtLeastOneAnimalAlive(hasAlive, allAnimals);
                statistics.DisplayDayStatistics(allAnimals, dayCounter);

            }
            statistics.DisplayFinalStatistics(allAnimals);
        }

        private void FeedAnimals(List<Food> allFoods, List<Animal> allAnimals)
        {
            List<List<string>> dailyRemarksOfAllAnimals = null;
            foreach (Animal animal in allAnimals.Where(x => x.IsAlive == true))
            {
                Food randomFood = animal.FindRandomFood(allFoods);
                animal.Eat(randomFood);
            }
        }

        private void CallForPlantsRegeneration(List<Food> allFoods)
        {
            foreach (Food food in allFoods.Where(x => x.IsPLant))
            {
                food.RegeneratePlants();
            }
        }


        private static bool CheckIsAtLeastOneAnimalAlive(bool hasAlive, List<Animal> allAnimals)
        {
            foreach (Animal animal in allAnimals)
            {
                if (animal.IsAlive)
                {
                    hasAlive = true;
                }
            }

            return hasAlive;
        }

    }
}
