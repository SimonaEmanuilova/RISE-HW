using L11_OOPEncapsulation.Foods;

namespace L11_OOPEncapsulation.Animals
{
    public class Nonspecified : Animal
    {
        public Nonspecified() : base(15, new HashSet<Food>() { new Milk() }, 16)
        {

        }

        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Milk(), new Seeds() };
        }




    }
}
