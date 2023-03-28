using L11_OOPEncapsulation.Foods;

namespace L11_OOPEncapsulation.Animals
{
    public class Herbivores : Animal
    {

        public Herbivores() : base(10, new HashSet<Food>() { new Seeds() }, 5)
        {
        }

        public override void MakeSoundWhenEating(Food food)
        {
            Console.WriteLine($"A wild Herbivore animal is eating {food.Name}.");
            //Console.WriteLine("Mmm leafes and seeds! Just what you need! Nom Nom.");
        }


        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Seeds(), new TallPlant() };
        }

        public override void CheckIfStarving()
        {
            if (Starving)
                Console.WriteLine($"A wild Herbivore animal is starving.");
        }


        public override void GetDyingAnimal()
        {
            Console.WriteLine("A wild Herbivore animal has died.");
        }
    }

}
