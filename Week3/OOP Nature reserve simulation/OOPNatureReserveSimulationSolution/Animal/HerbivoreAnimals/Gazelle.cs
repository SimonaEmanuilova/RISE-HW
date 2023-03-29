using OOPNatureReserveSimulationSolution.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals
{
    public class Gazelle : Herbivores
    {

        public Gazelle() : base("Gazelle",12, new HashSet<Food>() { new Milk() , new Seeds()}, 8)
        {
        }


        public override HashSet<Food> GetMatureDiet()
        {
            return new HashSet<Food> { new Milk(), new Seeds(), new TallPlant() , new Plant()};
        }


    }
}
