using OOPNatureReserveSimulationSolution.Animals;


namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class DetailedStatistics : IStatisticsDisplay
    {
        public void Display(List<Animal> allAnimals, int dayCounter)
        {                
            //DisplayDay(dayCounter);
        }

        public void DisplayDay(int dayCounter)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nDay {dayCounter}");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
