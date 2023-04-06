using OOPNatureReserveSimulationSolution.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Foods
{
    public class Plant : Food
    {

        public Plant() : base("Plant", 10)
        {
            this.IsPLant = true;
        }


    }
}
