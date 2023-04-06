namespace OOPNatureReserveSimulationSolution.Animals
{
    public class ConsoleEnglishLogger : IAnimalEvents
    {
        public bool Enabled { get; set; }

        public void Eat(string animalName, string? foodName, int? foodNutritionalValue)
        {
            WriteLine(foodName != null ? $"{animalName} ate {foodName} with {foodNutritionalValue} nutritional value" : $"{animalName} didn't eat");
        }
        private void WriteLine(string text)
        {
            if (Enabled)
                Console.WriteLine(text);
        }
        public void Mature(string animalName)
        {
            WriteLine($"{animalName} has it's birtday today! Happy birthaday, {animalName}!");
        }

        public void Starve(string animalName)
        {
            WriteLine($"{animalName} is starving");
        }

        public void Die(string animalName)
        {
                WriteLine($"{animalName} has died");
        }


    }
}
