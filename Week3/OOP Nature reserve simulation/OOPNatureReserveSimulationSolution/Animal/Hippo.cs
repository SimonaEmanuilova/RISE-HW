using L11_OOPEncapsulation.Foods;

namespace L11_OOPEncapsulation.Animals
{
    public class Hippo : Animal
    {
        public Hippo() : base(10, new HashSet<Food>() { new Milk(), new Seeds(), new Meat() })
        {
        }
    }
}
