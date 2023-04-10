using OOPNatureReserveSimulationSolution.Animals;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public interface IStatisticsDisplay
    {
        public void Display(List<Animal> allAnimals, int dayCounter);

    }
}
