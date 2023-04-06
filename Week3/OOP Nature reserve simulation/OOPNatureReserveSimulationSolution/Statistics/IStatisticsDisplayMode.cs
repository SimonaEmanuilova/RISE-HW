using OOPNatureReserveSimulationSolution.Animals;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public interface IStatisticsDisplayMode
    {
        public void Display(List<Animal> allAnimals, int dayCounter);

    }
}
