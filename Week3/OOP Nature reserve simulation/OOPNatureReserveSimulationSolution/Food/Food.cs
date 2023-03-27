using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11_OOPEncapsulation.Foods
{
    public class Food
    {
        public string Name { get; set; }    

        public Food() { 
        Name = string.Empty;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name);
        }

        public override bool Equals(object? obj)
        {
            return this.Name.Equals(((Food)obj).Name);
        }

    }
}
