using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.SimulationLogic;

namespace OOPNatureReserveSimulationSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleEnglishLogger logger = new ConsoleEnglishLogger();

            Main simulation = new Main(new AnimalGenerator(logger), new FoodGenerator(), logger, new Simulation());

            simulation.RunSimulation();
        }
    }
}