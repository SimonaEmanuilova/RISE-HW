﻿using OOPNatureReserveSimulationSolution.Animals.CarnivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.HerbivoreAnimals;
using OOPNatureReserveSimulationSolution.Animals.UnclassifiedAnimals;

namespace OOPNatureReserveSimulationSolution.Animals
{
    public class AnimalFactory
    {
        public Lion CreateLion() { return new Lion(10, 10); }

        public Gazelle CreateGazelle() { return new Gazelle(15, 15); }

        public Frog CreateFrog() { return new Frog(8, 8); }

        public Salmon CreateSalmon() { return new Salmon(8, 8); }

        public List<Animal> CreateAllAnimals()
        {

            List<Animal> allAnimals = new List<Animal>();

            Console.WriteLine("Choose number of Lions ");
            int numberOfLions = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLions; i++)
            {
                ; allAnimals.Add(CreateLion());
            }

            Console.WriteLine("Choose number of Gazelles ");
            int numberOfGazelles = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfGazelles; i++)
            {
                allAnimals.Add(CreateGazelle());
            }

            Console.WriteLine("Choose number of Frogs ");
            int numberOfFrogs = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfFrogs; i++)
            {
                allAnimals.Add(CreateFrog());
            }

            Console.WriteLine("Choose number of Salmons ");
            int numberOfSalmons = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfSalmons; i++)
            {
                allAnimals.Add(CreateSalmon());
            }

            return allAnimals;

        }

    }
}
