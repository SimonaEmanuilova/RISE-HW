using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Biomes;
using OOPNatureReserveSimulationSolution.SimulationLogic;

namespace OOPNatureReserveSimulationSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleEnglishLogger logger = new ConsoleEnglishLogger();

            Main simulation = new Main(new AnimalGenerator(logger), new FoodGenerator(), new BiomeGenerator(logger), logger, new Simulation());

            simulation.RunSimulation();
        }
    }
}