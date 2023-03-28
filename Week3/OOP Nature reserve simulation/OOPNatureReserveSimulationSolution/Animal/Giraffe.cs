using L11_OOPEncapsulation.Foods;

namespace L11_OOPEncapsulation.Animals
{
    public class Giraffe : Animal
    {

        public Giraffe() : base(10, new HashSet<Food>() { new Milk(), new Seeds() })
        {
        }



    }

}
