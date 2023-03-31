using OOPNatureReserveSimulationSolution.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class DetailedStats: IWriteStats
    {
        public void WriteStats(List<Animal> allAnimals)
        {
            foreach (Animal animal in allAnimals.Where(x => x.IsAlive))
            {
                Console.WriteLine(animal.Name + ":");
                animal.CongratulateMatured();
                Console.WriteLine("Energy: " + animal.Energy + "\n");
            }
        }
    }
}
