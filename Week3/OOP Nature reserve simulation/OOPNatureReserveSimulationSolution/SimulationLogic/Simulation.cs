using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Biomes;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Simulation
    {
        public void Run(Biome[,] biomes, Statistics statistics)
        {
            int dayCounter = 0;

            bool hasAlive = true;

            while (hasAlive)
            {
                dayCounter++;

                hasAlive = false;
                foreach (Biome biome in biomes)
                {
                    biome.FindNeighbours(biomes);
                }

                Console.ForegroundColor = ConsoleColor.Blue;   //TODO: move UI part in Statistic
                Console.WriteLine($"\nDAY {dayCounter}");
                Console.ForegroundColor = ConsoleColor.White;

                int biomeNumber = 1;
                foreach (Biome biome in biomes)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nBiome {biomeNumber} - {biome.Name} - Lunch time");

                    FeedAnimals(biome.Foods, biome.Animals);
                    CallForPlantsRegeneration(biome.Foods);
                    hasAlive = CheckIsAtLeastOneAnimalAlive(hasAlive, biome.Animals);
                    statistics.DisplayDayStatistics(biome.Animals, dayCounter);
                    biomeNumber++;
                }

                biomeNumber = 1;

                foreach (Biome biome in biomes)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nBiome {biomeNumber} - {biome.Name} - Migration time");

                    CallAnimalsForMigration(biome.Animals);
                    hasAlive = CheckIsAtLeastOneAnimalAlive(hasAlive, biome.Animals);
                    statistics.DisplayDayStatistics(biome.Animals, dayCounter);
                    biomeNumber++;
                }

            }
            //statistics.DisplayFinalStatistics(allAnimals); //TODO: make all animals from every biome in one list to view the final stats
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

    }
}
