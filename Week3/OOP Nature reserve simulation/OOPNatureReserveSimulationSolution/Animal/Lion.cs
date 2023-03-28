using L11_OOPEncapsulation.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11_OOPEncapsulation.Animals
{
    public class Lion : Animal
    {
        public Lion() : base(10, new HashSet<Food>() { new Meat(), new Milk() })
        {
        }
    }

}
