using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Biomes;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Statistics
    {

        private IStatisticsDisplay _statisticsDisplay;

        public Statistics(IStatisticsDisplay statisticsDisplay)
        {
            _statisticsDisplay = statisticsDisplay;
        }

        public void DisplayDayStatistics(List<Animal> allAnimals, int dayCounter)
        {
            this._statisticsDisplay.Display(allAnimals, dayCounter);
        }

        public void DisplayDayCounter(int dayCounter)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nDAY {dayCounter}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayMigrationTimeMessage(int biomeNumber, Biome biome)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nBiome {biomeNumber} - {biome.Name} - Migration time");
        }

        public void DisplayFeedTimeMessage(int biomeNumber, Biome biome)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nBiome {biomeNumber} - {biome.Name} - Lunch time");
        }

        public void DisplayFinalStatistics(List<Animal> allAnimals)
        {
            List<int> allLifeSpans = new List<int>();

            foreach (var animal in allAnimals)
            {
                allLifeSpans.Add(animal.LifeSpan);
            }

            int minLifeSpan = allLifeSpans.Min();
            int maxLifeSpan = allLifeSpans.Max();
            int averageLifeSpan = (minLifeSpan + maxLifeSpan) / 2;

            Console.WriteLine($"The minimum lifespan is: {minLifeSpan}");
            Console.WriteLine($"The maximum lifespan is: {maxLifeSpan}");
            Console.WriteLine($"The average lifespan is: {averageLifeSpan}");
        }


    }
}
