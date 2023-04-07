using OOPNatureReserveSimulationSolution.Biomes;
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

        public List<Biome> PossibleBiomes;
        public Biome CurrentBiome { get; set; }  

        protected readonly IAnimalEvents _events;


        public Animal(string name, int energy, int maxEnergy, List<Food> diet, List<Biome> possibleBiomes, int matureAge, IAnimalEvents events) : base(name, maxEnergy)
        {
            Energy = energy;
            MaxEnergy = maxEnergy;
            Diet = diet;
            PossibleBiomes = possibleBiomes;
            MatureAge = matureAge;
            this._events = events;
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

        public void Move()
        {
            if(!IsAlive) { return; }

            Biome chosenBiome = ChooseRandomDirection();
            if (PossibleBiomes.Contains(chosenBiome))
            {
                CurrentBiome.RemoveAnimal(this);
                chosenBiome.AddAnimal(this);
                _events.Move(this.Name, CurrentBiome, chosenBiome);

                CurrentBiome = chosenBiome;
            }
            _events.Move(this.Name, null, null);

        }

        public Biome ChooseRandomDirection()
        {
            Random random = new Random();
            Biome randomBiome = CurrentBiome.BiomeNeighbours.ElementAt(random.Next(CurrentBiome.BiomeNeighbours.Count));

            return randomBiome;
        }

        public void SetCurrentBiomeForAnimal(Biome biome) 
        {
            foreach (var animal in biome.Animals)
            {
                animal.CurrentBiome = biome;
            }


        }
    }

}
