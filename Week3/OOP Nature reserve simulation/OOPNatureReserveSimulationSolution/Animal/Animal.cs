﻿using OOPNatureReserveSimulationSolution.Foods;
using System.ComponentModel.Design;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public abstract class Animal : Food
    {
        public int Energy { get; private set; }
        public int MaxEnergy { get; private set; }

        public List<Food> Diet;
        public int LifeSpan { get; private set; } = 0;
        public bool IsAlive => Energy > 0 && NutritionalValue == MaxEnergy;
        public int MatureAge { get; private set; }
        public bool Starving => (Energy <= MaxEnergy / 2) ? true : false;

        public List<string> DailyRemarks;


        public Animal(string name, int energy, int maxEnergy, List<Food> diet, int matureAge) : base(name, maxEnergy)
        {
            Energy = energy;
            MaxEnergy = maxEnergy;
            Diet = diet;
            MatureAge = matureAge;
            DailyRemarks = new List<string>();

        }

        public Food FindRandomFood(List<Food> allFoods)
        {
            Random random = new Random();
            Food foodOfTheDay = allFoods.Where(x => x.NutritionalValue > 0).ElementAt(random.Next(allFoods.Where(x => x.NutritionalValue > 0).ToList().Count));

            return foodOfTheDay;
        }


        public void Eat(Food food)
        {
            if (!IsAlive) { return; }
            CheckIfStarving();
            ChooseDiet();

            if (Diet.Contains(food) && food.NutritionalValue > 0)
            {
                if (Energy < MaxEnergy)
                {
                    MakeSoundWhenEating(food);

                    Energy += food.RecalculateNutritionValue(MaxEnergy - Energy);
                }
                else
                {
                    Energy--;
                }
            }
            else
            {
                Energy--;
                DailyRemarks.Add($"{Name} didn't found anything to eat.");
            }
            LifeSpan++;

            CheckIfDying();
        }


        public virtual void ChooseDiet()
        {
            if (MatureAge == LifeSpan)
            {
                this.Diet = GetMatureDiet();
            }
        }

        public virtual void CongratulateIfMatured()
        {
            if (MatureAge == LifeSpan)
            {
                DailyRemarks.Add($"Today the {Name} matured! Happy birthay!");
            }
        }

        public abstract List<Food> GetMatureDiet();


        public virtual void MakeSoundWhenEating(Food food)
        {
            DailyRemarks.Add($"{Name} is eating {food.Name} with {food.NutritionalValue} nutritional Value.");
        }

        public virtual void MakeSoundWhenEating()
        {
            Console.WriteLine($"{Name} is eating.");

        }

        public virtual void CheckIfStarving()
        {
            if (Starving)
            {
                DailyRemarks.Add($"{Name} is starving.");
            }
        }

        public virtual void CheckIfDying()
        {
            if (!IsAlive)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                GetDyingAnimal();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public virtual void GetDyingAnimal()
        {
            DailyRemarks.Add($"{Name} has died.");
        }


    }

}
