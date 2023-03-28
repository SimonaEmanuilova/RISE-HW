using L11_OOPEncapsulation;
using L11_OOPEncapsulation.Animals;
using L11_OOPEncapsulation.Foods;


namespace L11_OOPEncapsulationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEatToCheckEnergyGivenMeatThatTheLionAndHippoEat()
        {

            HashSet<Animal> animals = new HashSet<Animal>() { new Giraffe(),
                new Lion(),
                new Hippo() };

            Food foodOftheDay = new Meat();

            List<int> expectedEnergy = new List<int>() { 9, 10, 10 };


            List<int> actualEnergy = new List<int>();

            foreach (Animal animal in animals)
            {
                animal.Eat(foodOftheDay);
                actualEnergy.Add(animal.Energy);
            }

            Assert.IsTrue(expectedEnergy.SequenceEqual(actualEnergy));
        }

        [TestMethod]
        public void TestEatToCheckEnergyGivenFoodThatNoOneEats()
        {

            HashSet<Animal> animals = new HashSet<Animal>() { new Giraffe(),
                new Lion(),
                new Hippo() };

            Food foodOftheDay = new ToxicMushroom();

            List<int> expectedEnergy = new List<int>() { 9, 9, 9 };


            List<int> actualEnergy = new List<int>();

            foreach (Animal animal in animals)
            {
                animal.Eat(foodOftheDay);
                actualEnergy.Add(animal.Energy);
            }

            Assert.IsTrue(expectedEnergy.SequenceEqual(actualEnergy));
        }

        [TestMethod]
        public void TestEatToCheckLifeSpanGrowForOneCycle()
        {

            HashSet<Animal> animals = new HashSet<Animal>() { new Giraffe(),
                new Lion(),
                new Hippo() };

            Food foodOftheDay = new Milk();

            List<int> expectedLifespan = new List<int>() { 1, 1, 1 };


            List<int> actualLifespan = new List<int>();

            foreach (Animal animal in animals)
            {
                animal.Eat(foodOftheDay);
                actualLifespan.Add(animal.LifeSpan);
            }

            Assert.IsTrue(expectedLifespan.SequenceEqual(actualLifespan));
        }

        [TestMethod]
        public void TestEatWhereAnimalDiesGivenFoodItDoesntEat()
        {
            HashSet<Animal> animals = new HashSet<Animal>() { new Giraffe { Energy = 1 }, new Lion { Energy = 1 }, new Hippo { Energy = 1 } };

            Food foodOftheDay = new Meat();

            List<bool> expectedIsAlife = new List<bool>() { false, true, true };

            List<bool> actualIsAlive = new List<bool>();

            foreach (Animal animal in animals)
            {
                animal.Eat(foodOftheDay);
                actualIsAlive.Add(animal.IsAlive);
            }

            Assert.IsTrue(expectedIsAlife.SequenceEqual(actualIsAlive));
        }
    }
}