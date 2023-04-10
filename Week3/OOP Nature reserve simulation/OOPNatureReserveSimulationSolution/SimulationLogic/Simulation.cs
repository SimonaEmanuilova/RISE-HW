using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Biomes;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Simulation
    {
        public void Run(Biome[,] biomes, Statistics statistics, List<Animal> allAnimals)
        {
            int dayCounter = 0;

            bool hasAlive = true;

            while (hasAlive)
            {
                dayCounter++;
                hasAlive = false;

                statistics.DisplayDayCounter(dayCounter);

                ManageFeedingTime(biomes, statistics, dayCounter, ref hasAlive);
                ManageMigration(biomes, statistics, dayCounter, ref hasAlive);

                ResetDailyData(allAnimals);
            }
            statistics.DisplayFinalStatistics(allAnimals);
        }

        private bool ManageMigration(Biome[,] biomes, Statistics statistics, int dayCounter, ref bool hasAlive)
        {
            int biomeNumber = 1;
            foreach (Biome biome in biomes)
            {
                statistics.DisplayMigrationTimeMessage(biomeNumber, biome);

                CallAnimalsForMigration(biome.Animals);

                hasAlive = CheckIsAtLeastOneAnimalAlive(hasAlive, biome.Animals);
                statistics.DisplayDayStatistics(biome.Animals, dayCounter);

                biomeNumber++;
            }

            return hasAlive;
        }

        private bool ManageFeedingTime(Biome[,] biomes, Statistics statistics, int dayCounter, ref bool hasAlive)
        {
            int biomeNumber = 1;
            foreach (Biome biome in biomes)
            {
                statistics.DisplayFeedTimeMessage(biomeNumber, biome);

                FeedAnimals(biome.Foods, biome.Animals);
                CallForPlantsRegeneration(biome.Foods);

                hasAlive = CheckIsAtLeastOneAnimalAlive(hasAlive, biome.Animals);
                statistics.DisplayDayStatistics(biome.Animals, dayCounter);

                biomeNumber++;
            }
            return hasAlive;
        }

        private void CallAnimalsForMigration(List<Animal> animalsInBiome)
        {

            List<Animal> staticAnimalsInBiome = new List<Animal>();

            foreach (var animal in animalsInBiome)
            {
                staticAnimalsInBiome.Add(animal);
            }

            foreach (Animal animal in staticAnimalsInBiome)
            {
                animal.Move();
            }
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

        private static void ResetDailyData(List<Animal> animals)
        {

            foreach (var animal in animals)
            {
                animal.ResetMovingPossibility();
            }

        }
    }
}
