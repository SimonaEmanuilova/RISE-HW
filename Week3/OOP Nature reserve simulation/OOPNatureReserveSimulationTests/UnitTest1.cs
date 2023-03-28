using L11_OOPEncapsulation;
using L11_OOPEncapsulation.Animals;
using L11_OOPEncapsulation.Foods;
using OOPNatureReserveSimulationSolution.Animals;

namespace L11_OOPEncapsulationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEatToCheckEnergyGivenMeatThatTheLionAndHippoEat()
        {

            HashSet<Animal> animals = new HashSet<Animal>() { new Lion { Energy = 10 }, new Salmon { Energy = 10 } , new Frog { Energy = 10}
                };

            Food randomFood = new Milk();

            List<int> expectedEnergy = new List<int>() { 10, 9, 9 };


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

            HashSet<Animal> animals = new HashSet<Animal>() { new Lion { Energy = 10 }, new Frog { Energy = 10 }, new Salmon { Energy = 10 }
               };

            Food randomFood = new ToxicMushroom();

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

            HashSet<Animal> animals = new HashSet<Animal>() { new Herbivores(),
                new Lion(),
                new Nonspecified() };

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
            HashSet<Animal> animals = new HashSet<Animal>() { new Lion { Energy = 1 }, new Frog { Energy = 1 }, new Salmon { Energy = 1 } };

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
    }
}