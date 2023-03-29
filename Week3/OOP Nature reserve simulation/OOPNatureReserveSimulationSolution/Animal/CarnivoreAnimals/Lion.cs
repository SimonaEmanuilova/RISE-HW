using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals
{
    public class Lion : Carnivores
    {
        public Lion() : base("Lion", 10, new HashSet<Food>() { new Milk(), new Meat() }, 6)
        {
        }
        public override HashSet<Food> GetMatureDiet()
        {
            return base.GetMatureDiet();
        }

    }
}
