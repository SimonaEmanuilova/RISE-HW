using OOPNatureReserveSimulationSolution.Foods;
using System.ComponentModel.Design;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public abstract class Animal : Food
    {
        public int Energy { get; set; }
        public int MaxEnergy { get; protected set; } = 10;

        public HashSet<Food> Diet;
        public int LifeSpan { get; private set; } = 0;
        public bool IsAlive => Energy > 0 && NutritionalValue == MaxEnergy;
        public int MatureAge { get; protected set; }
        public bool Starving => (Energy <= MaxEnergy / 2) ? true : false;


        public Animal(string name, int maxEnergy, HashSet<Food> diet, int matureAge) : base(name, maxEnergy)
        {
            Energy = maxEnergy;
            MaxEnergy = maxEnergy;
            Diet = diet;
            MatureAge = matureAge;
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
                    Energy += food.NutritionalValue;
                   

                    MakeSoundWhenEating(food);
                    RecalculateNutritionValueOfFood(food); 

                    if (Energy > MaxEnergy)
                    {
                        Energy = MaxEnergy;
                    }
                }
            }
            else
            {
                Energy--;
            }
            LifeSpan++;

            CheckIfDying();
        }

        private void RecalculateNutritionValueOfFood(Food food)
        {
            int NutritionalValueRemainder = Energy - MaxEnergy;

            if (NutritionalValueRemainder <= 0)
            {
                food.NutritionalValue = 0;
            }
            else { food.NutritionalValue = NutritionalValueRemainder; }
        }

        public virtual void ChooseDiet()
        {
            if (MatureAge == LifeSpan)
            {
                this.Diet = GetMatureDiet();
            }
        }

        public abstract HashSet<Food> GetMatureDiet();


        public virtual void MakeSoundWhenEating(Food food)
        {
            Console.WriteLine($"{Name} is eating {food.Name} with {food.NutritionalValue} nutritional Value.");
        }

        public virtual void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"{Name} is starving.");
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
            Console.WriteLine($"{Name} has died.");
        }

        public virtual void ChangeDietForCarnivores() { }

    }

}
