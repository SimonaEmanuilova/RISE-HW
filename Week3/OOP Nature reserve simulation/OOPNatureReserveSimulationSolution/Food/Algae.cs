using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Foods

{
    public class Algae : Food
    {
        public Algae():base("Algae",2)
        {
            this.IsPLant = true;
        }
    }
}
