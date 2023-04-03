using OOPNatureReserveSimulationSolution.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Statistics
    {

        private IStatisticsDisplayMode _statisticsDisplay;

        public Statistics(IStatisticsDisplayMode statisticsDisplay)
        {
            _statisticsDisplay = statisticsDisplay;
        }

        public void DisplayDayStatistics(List<Animal> allAnimals)
        {
            this._statisticsDisplay.Display(allAnimals);
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
