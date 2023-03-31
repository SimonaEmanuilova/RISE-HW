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