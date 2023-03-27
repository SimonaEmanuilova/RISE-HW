using L11_OOPEncapsulation.Animals;
using L11_OOPEncapsulation.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11_OOPEncapsulation.Animals
{
    internal class Hippo : Animal
    {
        public Hippo() : base(10, new HashSet<Food>() { new Milk(), new Seeds(), new Meat() })
        {
        }
    }
}
