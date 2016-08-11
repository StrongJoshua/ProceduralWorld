using System.Collections;

namespace ProceduralWorld {
	public class Biome {
		public enum Terrain { land, water }

		public static readonly double MaxFertility = 100;

		private static int nextOrdinal = 0;
		private static ArrayList all = new ArrayList();
		public static int BiomeCount { get { return nextOrdinal; } }

		public static readonly Biome water = new Biome(MaxFertility, Terrain.water);
		public static readonly Biome desert = new Biome(0);
		public static readonly Biome forest = new Biome(.9 * MaxFertility);

		public Terrain TerrainType { get; private set; }
		public double Fertility { get; private set; }
		public int Ordinal { get; private set; }

		private Biome(double fertility, Terrain ter = Terrain.land) {
			TerrainType = ter;
			Fertility = fertility;
			Ordinal = nextOrdinal++;
			all.Add(this);
		}

		public static bool ExistsOrdinal(int ordinal) {
			return ordinal >= 0 && ordinal < nextOrdinal;
		}

		public static Biome FromOrdinal(int ordinal) {
			foreach (Biome b in all)
				if (b.Ordinal == ordinal) return b;
			return null;
		}
	}
}
