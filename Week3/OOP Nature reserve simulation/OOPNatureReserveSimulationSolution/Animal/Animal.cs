using OOPNatureReserveSimulationSolution.Foods;
using System.ComponentModel.Design;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public abstract class Animal : Food
    {
        public int Energy { get; set; }
        public int MaxEnergy { get; set; } 

        public List<Food> Diet;
        public int LifeSpan { get; private set; } = 0;
        public bool IsAlive => Energy > 0 && NutritionalValue == MaxEnergy;
        public int MatureAge { get; protected set; }
        public bool Starving => (Energy <= MaxEnergy / 2) ? true : false;


        public Animal(string name, int maxEnergy, List<Food> diet, int matureAge) : base(name, maxEnergy)
        {
            Energy = maxEnergy;
            MaxEnergy = maxEnergy;
            Diet = diet;
            MatureAge = matureAge;
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
                    Energy+=RecalculateNutritionValue(MaxEnergy - Energy, food);
                    
                    MakeSoundWhenEating(food);
                }
                else
                {
                    Console.WriteLine($"{Name} is full. It will skip lunch today.");
                    Energy--;
                }
            }
            else
            {
                Energy--;
                Console.WriteLine($"{Name} didn't found anything to eat.");
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

        public virtual void CongratulateMatured()
        {

            if (MatureAge == LifeSpan)
            {
                Console.WriteLine($"Today the {Name} matured! Happy birthay!");
            }
        }

        public abstract List<Food> GetMatureDiet();


        public virtual void MakeSoundWhenEating(Food food)
        {

            Console.WriteLine($"{Name} is eating {food.Name} with {food.NutritionalValue} nutritional Value.");
        }

        public virtual void MakeSoundWhenEating()
        {
            Console.WriteLine($"{Name} is eating.");
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


    }

}
