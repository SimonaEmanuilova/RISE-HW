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
        private readonly OOPNatureReserveSimulationSolution.IAnimalGenerator _animalInitialiser;
        private readonly IFoodGenerator _foodInitialiser;

        public Simulation(OOPNatureReserveSimulationSolution.IAnimalGenerator animalInitialiser, IFoodGenerator foodInitialiser)
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

        protected void RegeneratePlants(List<Food> allFood)
        {
            foreach (Food food in allFood)
            {
                if (food.IsPLant && food.NutritionalValue < food.MaxNutritionalValue)
                {
                    food.NutritionalValue++;
                }
            }
        }

        public void RunSimulation()
        {
            Statistics statistic = new Statistics();

            bool hasAlive = true;

            List<Animal> allAnimals = _animalInitialiser.Generate();

            List<Food> allFoods = _foodInitialiser.Generate(allAnimals);

            int dayCounter = 0;

            Console.WriteLine("Welcome to Nature Simulator 3000!\n PLease select a View Mode - detailed / summary :");

            string detailLevel = Console.ReadLine().ToLower();


            while (hasAlive)
            {
                statistic.DisplayDayStats(detailLevel, allAnimals, dayCounter);

                dayCounter++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Day {dayCounter}");
                Console.ForegroundColor = ConsoleColor.White;

                hasAlive = false;

                FeedAnimals(allFoods, allAnimals);
                RegeneratePlants(allFoods);

                hasAlive = CheckIsAtLeastOneAnimalAlive(hasAlive, allAnimals);
            }
            statistic.DisplayFinalStats(allAnimals);
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
