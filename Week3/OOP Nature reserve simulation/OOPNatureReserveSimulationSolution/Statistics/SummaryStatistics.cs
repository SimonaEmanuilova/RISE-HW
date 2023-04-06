using OOPNatureReserveSimulationSolution.Animals;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class SummaryStatistics : IStatisticsDisplayMode
    {
        public SummaryStatistics() { }
        public void Display(List<Animal> allAnimals, int dayCounter)
        {
            DisplayDay(dayCounter);

            int aliveAnimals = 0;
            int deadAnimals = 0;
            foreach (Animal animal in allAnimals)
            {
                if (animal.IsAlive)
                {
                    aliveAnimals++;
                }
                else deadAnimals++;
            }
            Console.WriteLine($"Alive: {aliveAnimals}");
            Console.WriteLine($"Dead: {deadAnimals}\n");
        }

        private void DisplayDay(int dayCounter)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Day {dayCounter}");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
