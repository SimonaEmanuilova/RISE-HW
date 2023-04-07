using OOPNatureReserveSimulationSolution.Biomes;

namespace OOPNatureReserveSimulationSolution.Maps
{
    public class Map
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Biome[,] BiomesInMap { get; private set; }

        private readonly BiomeGenerator _biomeGenerator;

        public Map(int rows, int columns, BiomeGenerator biomeGenerator)
        {
            this.Rows = rows;
            this.Columns = columns;
            _biomeGenerator = biomeGenerator;
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

            return map;
        }


    }
}
