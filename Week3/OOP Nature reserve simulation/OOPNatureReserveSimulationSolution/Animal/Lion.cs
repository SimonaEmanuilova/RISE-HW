using L11_OOPEncapsulation.Foods;

namespace L11_OOPEncapsulation.Animals
{
    public class Lion : Animal
    {
        public Lion() : base(10, new HashSet<Food>() { new Meat(), new Milk() })
        {
        }
    }

}
