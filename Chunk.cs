using ProceduralWorld.Equations;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ProceduralWorld {
	enum Biomes { water, forest, desert }
	public class Chunk {
		readonly Point loc;
		Node[,] nodes;
		internal bool Loaded { get; private set; }
		internal Biomes Biome { get; private set; }

		internal Chunk(Point location, int size) {
			loc = location;
			Loaded = false;
			nodes = new Node[size, size];
		}

		internal void determine(Dictionary<Point, Chunk> chunks, Random rand) {
			float[] chances = new float[Enum.GetNames(typeof(Biomes)).Length + 1];
			chances[chances.Length - 1] += .2f;
			Point[] neighbors = new Point[] { new Point(loc.X, loc.Y + 1), new Point(loc.X + 1, loc.Y), new Point(loc.X, loc.Y - 1), new Point(loc.X - 1, loc.Y) };
			Chunk other;
			foreach (Point p in neighbors) {
				if (chunks.TryGetValue(p, out other)) {
					chances[(int)other.Biome] += .2f;
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
					if (Enum.IsDefined(typeof(Biomes), i)) {
						Biome = (Biomes)i;
					} else throw new Exception("Biome enum " + i + "is not defined.");
				}
			}
		}

		internal void load(Equation equation) {
			throw new NotImplementedException();
		}
	}
}
