using L11_OOPEncapsulation.Foods;

namespace L11_OOPEncapsulation.Animals
{
    public class Animal
    {
        public int Energy { get;  set; }
        public int MaxEnergy { get; set; } = 10;
        public HashSet<Food> Diet { get; private set; }
        public int LifeSpan { get; private set; } = 0;
        public bool IsAlive => Energy > 0;

        public Animal(int energy, HashSet<Food> diet )
        {
            Energy = energy;
            MaxEnergy = energy;            
            Diet = diet;
        }

        public void Eat(Food food)
        {
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

        }




    }

}
