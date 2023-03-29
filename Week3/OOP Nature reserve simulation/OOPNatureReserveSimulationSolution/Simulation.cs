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

        protected HashSet<Animal> InitializeAnimals()
        {
            HashSet<Animal> allAnimals = new HashSet<Animal>()
            {   new Gazelle(),
                new Lion(),
                new Frog(),
                new Salmon()
            };

            return allAnimals;
        }

        protected HashSet<Food> InitializeFoods()
        {
            HashSet<Food> allFoods = new HashSet<Food>() {
                new Meat(), new Milk(), new Seeds(), new TallPlant(),
                new ToxicMushroom(), new Algae(), new Insects(), new Krill() };

            return allFoods;
        }

        protected Food GetRandomFood(HashSet<Food> allFoods)
        {
            Random random = new Random();
            Food foodOfTheDay = allFoods.ElementAt(random.Next(allFoods.Count));

            return foodOfTheDay;
        }

        protected HashSet<Animal> FeedAnimals(HashSet<Food> allFoods, HashSet<Animal> allAnimals)
        {


            foreach (Animal animal in allAnimals)
            {
                Food randomFood = GetRandomFood(allFoods);
                animal.Eat(randomFood);
            }
            Console.WriteLine();
            return allAnimals;
        }

        protected void GetStatistic(HashSet<Animal> allAnimals)
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

        public void RunSimulation()
        {

            bool hasAlive = true;
            HashSet<Food> allFoods = InitializeFoods();
            HashSet<Animal> allAnimals = InitializeAnimals();

            while (hasAlive)
            {
                hasAlive = false;
                FeedAnimals(allFoods, allAnimals);

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




    }
}
