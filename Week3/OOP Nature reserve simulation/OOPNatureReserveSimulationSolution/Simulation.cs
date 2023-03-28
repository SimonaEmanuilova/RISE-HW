using L11_OOPEncapsulation.Animals;
using L11_OOPEncapsulation.Foods;
using OOPNatureReserveSimulationSolution.Animals;

namespace L11_OOPEncapsulation
{
    public class Simulation
    {
        public Simulation()
        {
        }

        protected HashSet<Animal> InitializeAnimals()
        {
            HashSet<Animal> allAnimals = new HashSet<Animal>()
            {   new Herbivores(),
                new Lion(),
                new Frog(),
                new Salmon(),
                new Nonspecified(),
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
                FeedAnimals(allFoods, allAnimals.Where(x => x.IsAlive == true).ToHashSet());
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
