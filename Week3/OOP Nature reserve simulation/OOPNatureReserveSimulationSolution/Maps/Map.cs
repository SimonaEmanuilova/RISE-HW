using OOPNatureReserveSimulationSolution.Animals;
using OOPNatureReserveSimulationSolution.Biomes;

namespace OOPNatureReserveSimulationSolution.Maps
{
    public class Map
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Biome[,] BiomesInMap { get; private set; }
        public List<Animal> allAnimals { get; private set; }

        private readonly BiomeGenerator _biomeGenerator;

        public Map(int rows, int columns, BiomeGenerator biomeGenerator)
        {
            this.Rows = rows;
            this.Columns = columns;
            _biomeGenerator = biomeGenerator;
            allAnimals = new List<Animal>();
        }

        public Biome[,] SetBiomesInMap(List<Biome> allPossibleBiomes)
        {
            Biome[,] map = new Biome[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    map[i, j] = _biomeGenerator.MakeRandomBiome(allPossibleBiomes);
                    map[i, j].SetLocation(i, j);
                }
            }

            BiomesInMap = map;
            SetNeighboursForBiomes();

            return map;
        }

        public void SetNeighboursForBiomes()
        {
            int[,] relativeNeighbourCoords = new int[,] {   //relative neighbour coordinates
                { 1, 0 }, { -1, 0 },
                { 0, 1 }, { 0, -1 },
                { 1, 1 }, { 1, -1 },
                { -1, 1 }, { -1, -1 }
            };
            foreach (var biome in BiomesInMap)
            {
                List<Biome> biomeNeighbors = new List<Biome>();

                for (int i = 0; i < relativeNeighbourCoords.GetLength(0); i++)
                {
                    int x = biome.xCordinate + relativeNeighbourCoords[i, 0];  //absolute neighbour coordinates
                    int y = biome.yCordinate + relativeNeighbourCoords[i, 1];

                    if (x >= 0 && x < BiomesInMap.GetLength(0) &&
                        y >= 0 && y < BiomesInMap.GetLength(1) &&
                       (x != biome.xCordinate || y != biome.yCordinate))
                    {
                        biomeNeighbors.Add(BiomesInMap[x, y]);
                    }
                }
                biome.SetNeighbors(biomeNeighbors);
            }
        }

    }
}
