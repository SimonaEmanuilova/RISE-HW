using OOPNatureReserveSimulationSolution.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public interface IStatisticsDisplayMode
    {
        public void Display(List<Animal> allAnimals, int dayCounter);

    }
}
