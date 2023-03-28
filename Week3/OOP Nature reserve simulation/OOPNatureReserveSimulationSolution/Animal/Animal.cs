using L11_OOPEncapsulation.Foods;

namespace L11_OOPEncapsulation.Animals
{
    public abstract class Animal
    {
        public int Energy { get;  set; }
        public int MaxEnergy { get; protected set; } = 10;
        public HashSet<Food> Diet { get; protected set; }
        public int LifeSpan { get; private set; } = 0;
        public bool IsAlive => Energy > 0;
        public int MatureAge { get; protected set; }
        public bool Starving => (Energy == MaxEnergy / 2) ? true : false;


        public Animal(int energy, HashSet<Food> diet, int matureAge)
        {
            Energy = energy;
            MaxEnergy = energy;
            Diet = diet;
            MatureAge = matureAge;
        }

        public void Eat(Food food)
        {
            CheckIfStarving();
            ChooseDiet();

            if (Diet.Contains(food))
            {
                if (Energy < MaxEnergy)
                    Energy++;
            }
            else
            {
                Energy--;
            }
            LifeSpan++;

            MakeSoundWhenEating(food);
            CheckIfDying();
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
            Console.WriteLine($"Nonspecified animal is eating {food.Name}.");
        }

        public virtual void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"Nonspecified animal is starving.");
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
            Console.WriteLine("Nonspecified animal has died.");
        }

    }

}
