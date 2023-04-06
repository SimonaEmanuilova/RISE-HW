using OOPNatureReserveSimulationSolution.Foods;

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
        public bool IsStarving => (Energy <= MaxEnergy / 2) ? true : false;

        protected readonly IAnimalEvents _events;


        //public List<string> DailyRemarks;


        public Animal(string name, int energy, int maxEnergy, List<Food> diet, int matureAge, IAnimalEvents events) : base(name, maxEnergy)
        {
            Energy = energy;
            MaxEnergy = maxEnergy;
            Diet = diet;
            MatureAge = matureAge;
            this._events = events;

            //DailyRemarks = new List<string>();

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

            if (Diet.Contains(food) && food.NutritionalValue > 0 && Energy < MaxEnergy)
            {
                MakeSoundWhenEating(food);
                _events.Eat(Name, food.Name, food.NutritionalValue);

                Energy += food.RecalculateNutritionValue(MaxEnergy - Energy);
            }
            else
            {
                Energy--;
                _events.Eat(Name, null, null);
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
                _events.Mature(Name);
            }
        }

        public abstract List<Food> GetMatureDiet();


        public virtual void MakeSoundWhenEating(Food food)
        {
        }

        public virtual void MakeSoundWhenEating()
        {
            Console.WriteLine($"{Name} is eating.");
        }

        public virtual void CheckIfStarving()
        {
            if (IsStarving)
            {
                _events.Starve(Name);
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
            _events.Die(Name);
        }


    }

}
