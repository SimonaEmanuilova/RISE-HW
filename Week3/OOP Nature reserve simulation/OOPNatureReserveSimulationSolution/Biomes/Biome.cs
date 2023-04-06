using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.SimulationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Biomes
{
    public class Biome
    {

        // must take simulation, animalsToGenerate,allFoods


        private readonly IAnimalGenerator _animalIGenerator;
        private readonly IFoodGenerator _foodGenerator;
        private readonly IAnimalEvents eventsLogger;
        private readonly Simulation _simulation;



        public Biome(IAnimalGenerator animalIGenerator, IFoodGenerator foodGenerator, IAnimalEvents languageLogger, Simulation simulation)
        {
            this._animalIGenerator = animalIGenerator;
            this._foodGenerator = foodGenerator;
            this.eventsLogger = languageLogger;
            _simulation = simulation;
        }

        public HashSet<Func<Animal>> GetPossibleAnimals()
        {
            AnimalGenerator animalGenerator = new AnimalGenerator(eventsLogger);

            HashSet<Func<Animal>> biomeSpecies = new HashSet<Func<Animal>> {
               //animalGenerator.CreateFrog(),
               //animalGenerator.CreateGazelle(),
               //animalGenerator.CreateSalmon()
            };

            return biomeSpecies;

        }

    }
}
