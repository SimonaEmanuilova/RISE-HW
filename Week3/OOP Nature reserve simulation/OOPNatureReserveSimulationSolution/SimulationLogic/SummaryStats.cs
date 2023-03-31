using OOPNatureReserveSimulationSolution.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class SummaryStats : IWriteStats
    {
        public  void WriteStats(List<Animal> allAnimals)
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

    }
}
