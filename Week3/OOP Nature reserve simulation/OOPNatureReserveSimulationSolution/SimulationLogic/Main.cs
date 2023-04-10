using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Biomes;
using OOPNatureReserveSimulationSolution.Foods;
using OOPNatureReserveSimulationSolution.Maps;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Main
    {
        private readonly IAnimalGenerator _animalInitialiser;
        private readonly IFoodGenerator _foodInitialiser;
        private readonly BiomeGenerator _biomeGenerator;
        private readonly IAnimalEvents _eventsLogger;
        private readonly Simulation _simulation;


        public Main(IAnimalGenerator animalInitialiser, IFoodGenerator foodInitialiser, BiomeGenerator biomeGenerator, IAnimalEvents languageLogger, Simulation simulation)
        {
            this._animalInitialiser = animalInitialiser;
            this._foodInitialiser = foodInitialiser;
            this._biomeGenerator = biomeGenerator;
            this._eventsLogger = languageLogger;
            this._simulation = simulation;
        }

        public void RunSimulation()
        {
            Console.WriteLine("Welcome to Nature Simulator 3000!\n");

            Map map = new Map(2, 2, _biomeGenerator);
            Biome[,] biomesInMap = map.SetBiomesInMap(_biomeGenerator.Generate());
            List<Animal> allAnimals = new List<Animal>();

            foreach (var biome in biomesInMap)
            {
                foreach (var animal in biome.Animals)
                {
                    allAnimals.Add(animal);
                }
            }

            Statistics statistics = ChooseStatisticsLevel(allAnimals);
            _simulation.Run(biomesInMap, statistics,allAnimals);
        }

        public Statistics ChooseStatisticsLevel(List<Animal> allAnimals)
        {
            Console.WriteLine("Enter 'detailed' or 'summary' to display statistics:");
            string detailLevel = Console.ReadLine().ToLower();
            Statistics statisticsMode;

            if (detailLevel == "summary")
            {
                _eventsLogger.Enabled = false;
                Statistics summaryStats = new Statistics(new SummaryStatistics());
                statisticsMode = summaryStats;
            }
            else if (detailLevel == "detailed")
            {
                _eventsLogger.Enabled = true;
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
