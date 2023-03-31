using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.SimulationLogic

{
    public  interface IFoodGenerator
    {
        List<Food> Generate(List<Animal> allAnimals);

    }
}
