namespace OOPNatureReserveSimulationSolution.Foods
{
    public class Food
    {
        public string Name { get; protected set; }
        public int NutritionalValue { get; set; }
        public int MaxNutritionalValue { get; set; }

        public bool IsPLant { get; protected set; }

        public Food(string name, int nutritionalValue)
        {
            Name = name;
            NutritionalValue = nutritionalValue;
            MaxNutritionalValue = nutritionalValue;

        }

        public int RecalculateNutritionValue(int energyDeficiency)
        {

            int animalEnergy;

            if (energyDeficiency >= NutritionalValue)
            {
                NutritionalValue = 0;
                animalEnergy = NutritionalValue;
            }
            else
            {
                NutritionalValue -= energyDeficiency;
                animalEnergy = energyDeficiency;
            }

            return animalEnergy;
        }

        public int RegeneratePlants()
        {
            if (IsPLant && NutritionalValue < MaxNutritionalValue)
            {
                NutritionalValue++;
            }
            return NutritionalValue;
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
