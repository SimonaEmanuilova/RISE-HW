using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.SimulationLogic

{
    public  interface IFoodGenerator
    {
        List<Food> Generate(List<Animal> allAnimals);

    }
}
