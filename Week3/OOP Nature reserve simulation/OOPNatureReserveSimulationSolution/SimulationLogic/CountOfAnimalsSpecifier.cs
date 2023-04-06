using OOPNatureReserveSimulationSolution.Animals;

namespace OOPNatureReserveSimulationSolution.SimulationLogic
{
    public class CountOfAnimalsSpecifier
    {
        public Dictionary<Func<Animal>, int> ChooseCountOfEachAnimal(HashSet<Func<Animal>> animalsToChooseFrom)
        {
            Dictionary<Func<Animal>, int> animalToNumber = new Dictionary<Func<Animal>, int>();

            foreach (Func<Animal> animal in animalsToChooseFrom)
            {

                Console.WriteLine($"{animal()}:");
                int numberOfAnimalsFromThisSpecie = Convert.ToInt32(Console.ReadLine());

                animalToNumber.Add(animal, numberOfAnimalsFromThisSpecie);
            }

            return animalToNumber;
        }
    }
}
