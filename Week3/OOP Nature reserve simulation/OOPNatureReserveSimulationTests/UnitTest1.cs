using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;



namespace L11_OOPEncapsulationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEatToCheckEnergyIncrease()
        {

            HashSet<Animal> animals = new HashSet<Animal>() { new Lion(9, 10) };

            Food randomFood = new Milk();

            List<int> expectedEnergy = new List<int>() { 10 };


            List<int> actualEnergy = new List<int>();

            foreach (Animal animal in animals)
            {
                animal.Eat(randomFood);
                actualEnergy.Add(animal.Energy);
            }

            Assert.IsTrue(expectedEnergy.SequenceEqual(actualEnergy));
        }

        [TestMethod]
        public void TestEatToCheckEnergyGivenFoodThatNoOneEats()
        {

            HashSet<Animal> animals = new HashSet<Animal>() { new Lion(10,10), new Frog(10,10), new Salmon(10,10)
               };


            Food randomFood = new Plant();

            List<int> expectedEnergy = new List<int>() { 9, 9, 9 };


            List<int> actualEnergy = new List<int>();

            foreach (Animal animal in animals)
            {
                animal.Eat(randomFood);
                actualEnergy.Add(animal.Energy);
            }

            Assert.IsTrue(expectedEnergy.SequenceEqual(actualEnergy));
        }

        [TestMethod]
        public void TestEatToCheckLifeSpanGrowForOneCycle()
        {

            HashSet<Animal> animals = new HashSet<Animal>() { new Frog(8,8),
                new Lion(10,10), new Gazelle(15,15)
               };

            Food randomFood = new Milk();

            List<int> expectedLifespan = new List<int>() { 1, 1, 1 };


            List<int> actualLifespan = new List<int>();

            foreach (Animal animal in animals)
            {
                animal.Eat(randomFood);
                actualLifespan.Add(animal.LifeSpan);
            }

            Assert.IsTrue(expectedLifespan.SequenceEqual(actualLifespan));
        }

        [TestMethod]
        public void TestEatWhereAnimalDiesGivenFoodItDoesntEat()
        {
            HashSet<Animal> animals = new HashSet<Animal>() { new Lion(1, 10), new Frog(1, 8), new Salmon(1, 8) };

            Food randomFood = new Milk();

            List<bool> expectedIsAlife = new List<bool>() { true, false, false };

            List<bool> actualIsAlive = new List<bool>();

            foreach (Animal animal in animals)
            {
                animal.Eat(randomFood);
                actualIsAlive.Add(animal.IsAlive);
            }

            Assert.IsTrue(expectedIsAlife.SequenceEqual(actualIsAlive));
        }


        [TestMethod]
        public void TestRegeneratePlantGivenPlantBelowMaxNutritionalValue()
        {
            Food food = new Plant { NutritionalValue = 9, MaxNutritionalValue = 10 };

            int expectedNutritionalValue = 10;
            int actualNutritionalValue = food.RegeneratePlants();

            Assert.AreEqual(expectedNutritionalValue, actualNutritionalValue);
        }

        [TestMethod]
        public void TestRegeneratePlantGivenPlantWithMaxNutritionalValue()
        {
            Food food = new Plant { NutritionalValue = 10, MaxNutritionalValue = 10 };

            int expectedNutritionalValue = 10;
            int actualNutritionalValue = food.RegeneratePlants();

            Assert.AreEqual(expectedNutritionalValue, actualNutritionalValue);
        }

        [TestMethod]
        public void TestRegeneratePlantGivenNotPlant()
        {
            Food food = new Meat { NutritionalValue = 9, MaxNutritionalValue = 10 };

            int expectedNutritionalValue = 9;
            int actualNutritionalValue = food.RegeneratePlants();

            Assert.AreEqual(expectedNutritionalValue, actualNutritionalValue);
        }

    }
}