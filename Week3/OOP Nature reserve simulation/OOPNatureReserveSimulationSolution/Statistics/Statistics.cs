using OOPNatureReserveSimulationSolution.Animals;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Statistics
    {

        private IStatisticsDisplayMode _statisticsDisplay;

        public Statistics(IStatisticsDisplayMode statisticsDisplay)
        {
            _statisticsDisplay = statisticsDisplay;
        }

        public void DisplayDayStatistics(List<Animal> allAnimals, int dayCounter)
        {
            this._statisticsDisplay.Display(allAnimals, dayCounter);
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
