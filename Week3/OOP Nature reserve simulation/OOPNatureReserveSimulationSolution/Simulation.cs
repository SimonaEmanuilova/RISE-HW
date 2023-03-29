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

        protected HashSet<Food> InitializeFoods(HashSet<Animal> allAnimals)
        {
            HashSet<Food> allFoods = new HashSet<Food>(allAnimals) {
                new Meat(), new Milk(), new Seeds(), new TallPlant(),
                new ToxicMushroom(), new Algae(), new Insects(), new Krill(), new Plant() };

            return allFoods;
        }

        protected Food GetRandomFood(HashSet<Food> allFoods)
        {
            Random random = new Random();
            Food foodOfTheDay = allFoods.Where(x => x.NutritionalValue > 0).ElementAt(random.Next(allFoods.Where(x => x.NutritionalValue > 0).ToHashSet().Count));

            return foodOfTheDay;
        }

        protected HashSet<Animal> FeedAnimals(HashSet<Food> allFoods, HashSet<Animal> allAnimals)
        {

            foreach (Animal animal in allAnimals.Where(x => x.IsAlive == true))
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

        protected void RegeneratePlants(HashSet<Food> allFood)
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
            HashSet<Animal> allAnimals = InitializeAnimals();

            HashSet<Food> allFoods = InitializeFoods(allAnimals);
            int dayCounter = 0;

            while (hasAlive)
            {
                dayCounter++;
                Console.WriteLine($"Day {dayCounter}");
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




    }
}
