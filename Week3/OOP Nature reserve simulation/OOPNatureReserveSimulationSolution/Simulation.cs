﻿using L11_OOPEncapsulation.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L11_OOPEncapsulation.Foods;

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
            {   new Giraffe(),
                new Lion(),
                new Hippo(), new Hippo() , new Hippo()
            };

            return allAnimals;
        }

        protected HashSet<Food> InitializeFoods()
        {
            Meat meat = new Meat();
            Milk milk = new Milk();
            Seeds seeds = new Seeds();
            ToxicMushroom toxicMushroom = new ToxicMushroom();
            HashSet<Food> allFoods = new HashSet<Food>() { meat, milk, seeds, toxicMushroom };

            return allFoods;
        }

        protected Food GetRandomFood(HashSet<Food> allFoods)
        {
            Random random = new Random();
            Food foodOfTheDay = allFoods.ElementAt(random.Next(allFoods.Count));

            return foodOfTheDay;
        }

        protected HashSet<Animal> FeedAnimals(Food foodOfTheDay, HashSet<Animal> allAnimals)
        {
            foreach (Animal animal in allAnimals)
            {
                animal.Eat(foodOfTheDay);
            }

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
                Food foodOfTheDay = GetRandomFood(allFoods);
                FeedAnimals(foodOfTheDay, allAnimals.Where(x => x.IsAlive == true).ToHashSet());
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
