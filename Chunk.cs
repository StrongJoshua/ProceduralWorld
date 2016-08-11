using ProceduralWorld.Equations;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ProceduralWorld {
	public class Chunk {
		readonly int size;
		readonly Point loc;
		public Node[,] Nodes { get; private set; }
		public bool Loaded { get; private set; }
		public Biome Biome { get; private set; }

		internal Chunk(Point location, int size) {
			loc = location;
			Loaded = false;
			this.size = size;
			Nodes = new Node[size, size];
			for (int i = 0; i < Nodes.GetLength(0); i++)
				for (int j = 0; j < Nodes.GetLength(1); j++)
					Nodes[i, j] = new Node();
		}

		internal void determine(Dictionary<Point, Chunk> chunks, Random rand) {
			float[] chances = new float[Biome.BiomeCount + 1];
			chances[chances.Length - 1] += .2f;
			Point[] neighbors = new Point[] { new Point(loc.X, loc.Y + 1), new Point(loc.X + 1, loc.Y), new Point(loc.X, loc.Y - 1), new Point(loc.X - 1, loc.Y) };
			Chunk other;
			foreach (Point p in neighbors) {
				if (chunks.TryGetValue(p, out other)) {
					chances[other.Biome.Ordinal] += .2f;
				} else chances[chances.Length - 1] += .2f;
			}
			float errorCheck = 0;
			foreach (float f in chances)
				errorCheck += f;
			if (errorCheck != 1f) throw new Exception("Error: Chunk determination experienced a calculation error. " + errorCheck + " should be 1");
			double value = rand.NextDouble();
			for (int i = 0; i < chances.Length; i++) {
				float f = chances[i];

				if (value > f) {
					value -= f;
				} else {
					if (i == chances.Length - 1) {
						i = rand.Next(0, chances.Length - 1);
					}
					if (Biome.ExistsOrdinal(i)) {
						Biome = Biome.FromOrdinal(i);
						return;
					} else throw new Exception("Biome enum " + i + " is not defined.");
				}
			}
		}

		internal void load(Equation equation, Random rand) {
			if (Loaded) throw new Exception("Chunk already loaded");
			Point center = new Point(size / 2, size / 2);
			for (int x = 0; x < size; x++) {
				for (int y = 0; y < size; y++) {
					Node n = Nodes[x, y];
					double mainEval = equation.evaluate(distance(center, new Point(x, y)));

					if (Biome.TerrainType == Biome.Terrain.water && rand.NextDouble() < mainEval) n.Terrain = Biome.Terrain.water;
					else n.Terrain = Biome.Terrain.land;

					n.Fertility = mainEval * Biome.Fertility;
				}
			}

			Loaded = true;
		}

		private double distance(Point p1, Point p2) {
			double x = p1.X - p2.X;
			double y = p1.Y - p2.Y;
			return Math.Sqrt(x * x + y * y);
		}
	}
}
