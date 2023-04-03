using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.SimulationLogic;


namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class Simulation
    {
        private readonly IAnimalGenerator _animalInitialiser;
        private readonly IFoodGenerator _foodInitialiser;


        public Simulation(IAnimalGenerator animalInitialiser, IFoodGenerator foodInitialiser)
        {
            this._animalInitialiser = animalInitialiser;
            this._foodInitialiser = foodInitialiser;
        }

        protected List<Animal> FeedAnimals(List<Food> allFoods, List<Animal> allAnimals)
        {

            foreach (Animal animal in allAnimals.Where(x => x.IsAlive == true))
            {
                Food randomFood = animal.FindRandomFood(allFoods);
                animal.Eat(randomFood);
            }
            Console.WriteLine();
            return allAnimals;
        }

        public void CallForPlantsRegeneration(List<Food> allFoods)
        {
            foreach (Food food in allFoods)
            {
                if (food.IsPLant) { food.RegeneratePlants(food); }

            }
        }

        public void RunSimulation()
        {
            Console.WriteLine("Welcome to Nature Simulator 3000!\n");

            bool hasAlive = true;

            List<Animal> allAnimals = _animalInitialiser.Generate();

            List<Food> allFoods = _foodInitialiser.Generate(allAnimals);

            int dayCounter = 0;
    

            Statistics statistics = ChooseStatisticsLevel(allAnimals);

            while (hasAlive)
            {

                dayCounter++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Day {dayCounter}");
                Console.ForegroundColor = ConsoleColor.White;

                hasAlive = false;

                FeedAnimals(allFoods, allAnimals);
                CallForPlantsRegeneration(allFoods);

                hasAlive = CheckIsAtLeastOneAnimalAlive(hasAlive, allAnimals);
                statistics.DisplayDayStatistics(allAnimals);

            }
            statistics.DisplayFinalStatistics(allAnimals);
        }

        public Statistics ChooseStatisticsLevel(List<Animal> allAnimals)
        {
            Console.WriteLine("Enter 'detailed' or 'summary' to display statistics:");
            string detailLevel = Console.ReadLine().ToLower();
            Statistics statisticsMode = null;

            if (detailLevel == "summary")
            {
                Statistics summaryStats = new Statistics(new SummaryStatistics());
                statisticsMode = summaryStats;
            }
            else if (detailLevel == "detailed")
            {
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

        private static bool CheckIsAtLeastOneAnimalAlive(bool hasAlive, List<Animal> allAnimals)
        {
            foreach (Animal animal in allAnimals)
            {
                if (animal.IsAlive)
                {
                    hasAlive = true;
                }
            }

            return hasAlive;
        }
    }
}
