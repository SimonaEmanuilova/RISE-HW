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

        public void FindNeighbours(Biome[,] map)
        {
            List<Biome> biomeNeighbors = new List<Biome>();
            int[,] relativeNeighbourCoords = new int[,] {   //relative neighbour coordinates
                { 1, 0 }, { -1, 0 },
                { 0, 1 }, { 0, -1 },
                { 1, 1 }, { 1, -1 },
                { -1, 1 }, { -1, -1 }
            };

            for (int i = 0; i < relativeNeighbourCoords.GetLength(0); i++)
            {
                int x = this.xCordinate + relativeNeighbourCoords[i, 0];  //absolute neighbour coordinates
                int y = this.yCordinate + relativeNeighbourCoords[i, 1];

                if (x >= 0 && x < map.GetLength(0) &&
                    y >= 0 && y < map.GetLength(1) &&
                   (x != this.xCordinate || y != this.yCordinate))
                {
                    biomeNeighbors.Add(map[x, y]);
                }
            }

            this.BiomeNeighbours = biomeNeighbors;
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
