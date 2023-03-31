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

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name);
        }

        public override bool Equals(object? obj)
        {
            return this.Name.Equals(((Food)obj).Name);
        }

        //public void ReduceNutritionValueOfFood(int nutritionalValueRemainder)
        //{
        //    if (nutritionalValueRemainder <= 0)
        //    {
        //        NutritionalValue = 0;
        //    }
        //    else { NutritionalValue = nutritionalValueRemainder; }
        //}

        public int RecalculateNutritionValue(int energyDeficiency, Food food)
        {

            int animalEnergy;

            if (energyDeficiency >= NutritionalValue)
            {
                food.NutritionalValue = 0;
                animalEnergy = NutritionalValue;
            }
            else
            {
                food.NutritionalValue -= energyDeficiency;
                animalEnergy = energyDeficiency;
            }

            return animalEnergy;
        }

    }
}
