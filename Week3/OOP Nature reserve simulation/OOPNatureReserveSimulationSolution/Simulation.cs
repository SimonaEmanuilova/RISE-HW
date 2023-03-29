using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;

namespace OOPNatureReserveSimulationSolution
{
    public class Simulation
    {
        public Simulation()
        {
        }

        protected List<Animal> InitializeAnimals()
        {
            List<Animal> allAnimals = new List<Animal>()
            {   new Gazelle(),new Gazelle(),
                new Lion(),
                new Frog(),
                new Salmon()
            };

            return allAnimals;
        }

        protected List<Food> InitializeFoods(List<Animal> allAnimals)
        {
            List<Food> allFoods = new List<Food>(allAnimals) {
                new Meat(), new Milk(), new Seeds(), new TallPlant(),
                new ToxicMushroom(), new Algae(), new Insects(), new Krill(), new Plant() };
            
            return allFoods;
        }

        protected Food GetRandomFood(List<Food> allFoods)
        {
            Random random = new Random();
            Food foodOfTheDay = allFoods.Where(x => x.NutritionalValue > 0).ElementAt(random.Next(allFoods.Where(x => x.NutritionalValue > 0).ToList().Count));

            return foodOfTheDay;
        }

        protected List<Animal> FeedAnimals(List<Food> allFoods, List<Animal> allAnimals)
        {

            foreach (Animal animal in allAnimals.Where(x => x.IsAlive == true))
            {
                Food randomFood = GetRandomFood(allFoods);
                animal.Eat(randomFood);
            }
            Console.WriteLine();
            return allAnimals;
        }

        protected void GetStatistic(List<Animal> allAnimals)
        {
            List<int> allLifeSpans = new List<int>();

            foreach (var animal in allAnimals)
            {
                allLifeSpans.Add(animal.LifeSpan);
            }

            int minLifeSpan = allLifeSpans.Min();
            int maxLifeSpan = allLifeSpans.Max();
            int averageLifeSpan = (minLifeSpan + maxLifeSpan) / 2;

            Console.WriteLine($"The minimum lifespan is: {minLifeSpan}");
            Console.WriteLine($"The maximum lifespan is: {maxLifeSpan}");
            Console.WriteLine($"The average lifespan is: {averageLifeSpan}");
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

            bool hasAlive = true;
            List<Animal> allAnimals = InitializeAnimals();

            List<Food> allFoods = InitializeFoods(allAnimals);

            int dayCounter = 0;

            Console.WriteLine("Welcome to Nature Simulator 3000!\n PLease select a View Mode - detailed / summary :");
            string detailLevel = Console.ReadLine().ToLower();

            while (hasAlive)
            {
                DisplayResults(detailLevel, allAnimals, dayCounter);

                dayCounter++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Day {dayCounter}");
                Console.ForegroundColor = ConsoleColor.White;

                hasAlive = false;
                FeedAnimals(allFoods, allAnimals);
                RegeneratePlants(allFoods);
                foreach (Animal animal in allAnimals)
                {
                    if (animal.IsAlive)
                    {
                        hasAlive = true;
                    }
                }
            }
            GetStatistic(allAnimals);
        }

        public void DisplayResults(string detailLevel, List<Animal> allAnimals, int dayCounter)
        {

            if (detailLevel == "summary")
            {
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
            else if (detailLevel == "detailed")
            {
                foreach (Animal animal in allAnimals.Where(x => x.IsAlive))
                {
                    Console.WriteLine(animal.Name + ":");    
                    animal.CongratulateMatured();
                    Console.WriteLine("Energy: " + animal.Energy + "\n");
                }


            }

            else { Console.WriteLine("Please select a detail level to view the statistic of the simulation."); }



        }


    }
}
