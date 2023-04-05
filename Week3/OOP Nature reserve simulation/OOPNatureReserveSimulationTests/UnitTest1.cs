using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution;

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
            Animal animal = new Lion(9, 10, animalEvents);
            Food food = new Milk();

            int expectedEnergy = 10;
            int actualEnergy;

            animal.Eat(food);
            actualEnergy = animal.Energy;

            Assert.AreEqual(expectedEnergy, actualEnergy);
        }

        [TestMethod]
        public void TestIfAnimalsDecreaseEnergyWhenEatingFoodThatIsNotInTheirDiet()
        {
            HashSet<Animal> animals = new HashSet<Animal>() {
                new Lion(10, 10, animalEvents),
                new Frog(10, 10, animalEvents),
                new Salmon(10, 10, animalEvents)
            };
            Food food = new Plant();

            List<int> expectedEnergy = new List<int>() { 9, 9, 9 };
            List<int> actualEnergy = new List<int>();

            foreach (Animal animal in animals)
            {
                animal.Eat(food);
                actualEnergy.Add(animal.Energy);
            }

            Assert.IsTrue(expectedEnergy.SequenceEqual(actualEnergy));
        }

        [TestMethod]
        public void TestIfTheLifespanOfAnAnimalIncreasesWhenADayHasGoneByAndItIsStillAlive()
        {
            Animal animal = new Frog(10, 10, animalEvents);   //when we create the animal, its lifespan starts from 0
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
            Animal animal = new Frog(1, 8, animalEvents);
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