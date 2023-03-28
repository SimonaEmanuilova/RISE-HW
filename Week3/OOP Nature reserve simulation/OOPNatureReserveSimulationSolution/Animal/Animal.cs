using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L11_OOPEncapsulation;
using L11_OOPEncapsulation.Foods;

namespace L11_OOPEncapsulation.Animals
{
    public class Animal
    {
        public int Energy { get;  set; }
        public int MaxEnergy { get; private set; }
        public HashSet<Food> Diet { get; private set; }
        public int LifeSpan { get; private set; } = 0;
        public bool IsAlive => Energy > 0;

        public Animal(int energy, HashSet<Food> diet)
        {
            Energy = energy;
            Diet = diet;
        }

        public void Eat(Food food)
        {
            if (!IsAlive) { Console.WriteLine("The animal cannot eat."); }

            else
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

}
