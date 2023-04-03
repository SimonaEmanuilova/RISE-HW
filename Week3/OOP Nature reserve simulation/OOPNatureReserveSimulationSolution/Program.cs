using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.SimulationLogic;

namespace OOPNatureReserveSimulationSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation(new AnimalGenerator(), new FoodGenerator());

            simulation.RunSimulation();
        }
    }
}