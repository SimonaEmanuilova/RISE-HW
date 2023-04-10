using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Foods;

namespace OOPNatureReserveSimulationSolution.Biomes
{
    public abstract class Biome
    {
        public string Name { get; private set; }
        public List<Animal> Animals { get; protected set; }
        public List<Food> Foods { get; protected set; }
        public int xCordinate { get; private set; }
        public int yCordinate { get; private set; }

        protected readonly IAnimalEvents _events;
        public List<Biome> BiomeNeighbours { get; private set; }

        public Biome(string name, IAnimalEvents events)
        {
            this.Name = name;
            this._events = events;
        }

        public abstract List<Animal> SetAnimals();
        public abstract List<Food> SetFoods();

        public virtual void GenerateAnimals()
        {
            this.Animals = SetAnimals();
        }

        public virtual void GenerateFoods()
        {
            this.Foods = SetFoods();
        }

        public void SetLocation(int x, int y)
        {
            this.xCordinate = x;
            this.yCordinate = y;
        }

        public void SetNeighbors(List<Biome> neighbors)
        {
            this.BiomeNeighbours = neighbors;
        }

        public void RemoveAnimal(Animal animal)
        {
            this.Animals.Remove(animal);
            this.Foods.Remove(animal);
        }

        public void AddAnimal(Animal animal)
        {
            this.Animals.Add(animal);
            this.Foods.Add(animal);

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name);
        }

        public override bool Equals(object? obj)
        {
            return this.Name.Equals(((Biome)obj).Name);
        }

        public abstract Biome CreateNewInstance();

    }
}
