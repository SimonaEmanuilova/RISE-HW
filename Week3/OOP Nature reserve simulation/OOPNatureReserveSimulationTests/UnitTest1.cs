using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;

namespace L11_OOPEncapsulationTests
{
    [TestClass]
    public class UnitTest1
    {
        ConsoleEnglishLogger animalEvents;

        [TestInitialize]
        public void Initialize()
        {
            animalEvents = new ConsoleEnglishLogger();
        }

        [TestMethod]
        public void TestIfAnimalIncreasesEnergyWhenEatingFoodInItsDiet()
        {

            int lionCurrentEnergy = 9;
            int lionMaxEnergy = 10;
            Animal animal = new Lion(lionCurrentEnergy, lionMaxEnergy, animalEvents);
            Food food = new Milk();

            int expectedEnergy = 10;
            int actualEnergy;

            animal.Eat(food);
            actualEnergy = animal.Energy;

            Assert.AreEqual(expectedEnergy, actualEnergy);
        }

        [TestMethod]
        public void TestIfAnimalDecreasesEnergyWhenEatingFoodThatIsNotInItsDiet()
        {
            int lionCurrentEnergy = 10;
            int lionMaxEnergy = 10;
            Animal animal = new Lion(lionCurrentEnergy, lionMaxEnergy, animalEvents);
            Food food = new Plant();

            int expectedEnergy = 9;
            int actualEnergy;

            animal.Eat(food);
            actualEnergy = animal.Energy;

            Assert.AreEqual(expectedEnergy, actualEnergy);
        }

        [TestMethod]
        public void TestIfTheLifespanOfAnAnimalIncreasesWhenADayHasGoneByAndItIsStillAlive()
        {
            int frogCurrentEnergy = 10;
            int frogMaxEnergy = 10;
            Animal animal = new Frog(frogCurrentEnergy, frogMaxEnergy, animalEvents);   //when we create the animal, its lifespan starts from 0
            Food food = new Algae();

            int expectedLifespan = 1;
            int actualLifespan;

            animal.Eat(food);
            actualLifespan = animal.LifeSpan;

            Assert.AreEqual(expectedLifespan, actualLifespan);
        }

        [TestMethod]
        public void TestIfTheAnimalDiesWhenItHasOneEnergyBarLeftAndDoesntFindFoodInItsDiet()
        {
            int frogCurrentEnergy = 1;
            int frogMaxEnergy = 8;
            Animal animal = new Frog(frogCurrentEnergy, frogMaxEnergy, animalEvents);
            Food food = new Milk();

            bool expectedIsAlive = false;
            bool actualIsAlive;

            animal.Eat(food);
            actualIsAlive = animal.IsAlive;

            Assert.AreEqual(expectedIsAlive, actualIsAlive);
        }

        [TestMethod]
        public void TestIfPlantRegeneratesItsNutritionalValueWhenItIsBelowItsMaxNutritionalValue()
        {
            Food plant = new Plant { NutritionalValue = 9, MaxNutritionalValue = 10 };

            int expectedNutritionalValue = 10;
            int actualNutritionalValue = plant.RegeneratePlants();

            Assert.AreEqual(expectedNutritionalValue, actualNutritionalValue);
        }

        [TestMethod]
        public void TestThatPlantDoesntRegenerateItsNutritionalValueWhenItIsAlreadyWithMaxNutritionalValue()
        {
            Food plant = new Plant { NutritionalValue = 10, MaxNutritionalValue = 10 };

            int expectedNutritionalValue = 10;
            int actualNutritionalValue = plant.RegeneratePlants();

            Assert.AreEqual(expectedNutritionalValue, actualNutritionalValue);
        }

        [TestMethod]
        public void TestThatFoodThatIsNotAPlantDoesntRegenerateItsNutritionalValue()
        {
            Food food = new Meat { NutritionalValue = 9, MaxNutritionalValue = 10 };

            int expectedNutritionalValue = 9;
            int actualNutritionalValue = food.RegeneratePlants();

            Assert.AreEqual(expectedNutritionalValue, actualNutritionalValue);
        }

    }
}