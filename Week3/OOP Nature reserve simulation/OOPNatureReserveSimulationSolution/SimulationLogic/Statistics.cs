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
        public Statistics() { }
        public void DisplayDayStats(string detailLevel, List<Animal> allAnimals, int dayCounter)
        {

            if (detailLevel == "summary")
            {
                int aliveAnimals = 0;
                int deadAnimals = 0;
                foreach (Animal animal in allAnimals)
                {
                    if (animal.IsAlive)
                    {
                        aliveAnimals++;
                    }
                    else deadAnimals++;
                }
                Console.WriteLine($"Alive: {aliveAnimals}");
                Console.WriteLine($"Dead: {deadAnimals}\n");

            }
            else if (detailLevel == "detailed")
            {
                foreach (Animal animal in allAnimals.Where(x => x.IsAlive))
                {
                    Console.WriteLine(animal.Name + ":");
                    animal.CongratulateMatured();
                    Console.WriteLine("Energy: " + animal.Energy + "\n");
                }
            }

            else { Console.WriteLine("Please select a detail level to view the statistic of the simulation."); }
        }


        public void DisplayFinalStats(List<Animal> allAnimals)
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
