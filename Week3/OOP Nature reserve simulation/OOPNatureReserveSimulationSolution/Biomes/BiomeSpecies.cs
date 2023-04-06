using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPNatureReserveSimulationSolution.Biomes
{
    public class BiomeSpecies
    {
        private readonly IAnimalEvents _eventsLogger;
        private readonly AnimalGenerator _animalGenerator;

        public BiomeSpecies(IAnimalEvents eventsLogger, AnimalGenerator animalGenerator)
        {
            this._eventsLogger = eventsLogger;
            this._animalGenerator = animalGenerator;
        }

        //TODO: pass the AnimalGenerator and the eventLogger through the constructor

        public HashSet<Animal> GetOceanAnimalsCatalogue()
        {
            HashSet<Animal> biomeSpecies = new HashSet<Animal> {
               _animalGenerator.CreateSalmon(),
            };

            return biomeSpecies;
        }

        public HashSet<Animal> GetSavannahAnimalsCatalogue()
        {
            HashSet<Animal> biomeSpecies = new HashSet<Animal> {
               _animalGenerator.CreateLion(),
               _animalGenerator.CreateGazelle(),
            };

            return biomeSpecies;
        }



    }

}

