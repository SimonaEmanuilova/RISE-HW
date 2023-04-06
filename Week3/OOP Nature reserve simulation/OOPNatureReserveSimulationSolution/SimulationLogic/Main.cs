using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;


namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Main
    {
        private readonly IAnimalGenerator _animalInitialiser;
        private readonly IFoodGenerator _foodInitialiser;
        private readonly IAnimalEvents eventsLogger;
        private readonly Simulation _simulation;

        public Main(IAnimalGenerator animalInitialiser, IFoodGenerator foodInitialiser, IAnimalEvents languageLogger, Simulation simulation)
        {
            this._animalInitialiser = animalInitialiser;
            this._foodInitialiser = foodInitialiser;
            this.eventsLogger = languageLogger;
            this._simulation = simulation;
        }

        public void RunSimulation()
        {
            Console.WriteLine("Welcome to Nature Simulator 3000!\n");

            List<Animal> allAnimals = _animalInitialiser.Generate();
            List<Food> allFoods = _foodInitialiser.Generate(allAnimals);
            Statistics statistics = ChooseStatisticsLevel(allAnimals);

            _simulation.Run(allAnimals, allFoods, statistics);
        }

        public Statistics ChooseStatisticsLevel(List<Animal> allAnimals)
        {
            Console.WriteLine("Enter 'detailed' or 'summary' to display statistics:");
            string detailLevel = Console.ReadLine().ToLower();
            Statistics statisticsMode;

            if (detailLevel == "summary")
            {
                eventsLogger.Enabled = false;
                Statistics summaryStats = new Statistics(new SummaryStatistics());
                statisticsMode = summaryStats;
            }
            else if (detailLevel == "detailed")
            {
                eventsLogger.Enabled = true;
                Statistics detailedStats = new Statistics(new DetailedStatistics());
                statisticsMode = detailedStats;
            }
            else
            {
                Console.WriteLine("Please select a detail level to view the statistic of the simulation.");
                throw new Exception();
            }

            return statisticsMode;
        }


    }
}
