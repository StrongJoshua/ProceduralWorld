using ProceduralWorld.Equations;
using ProceduralWorld.WorldOptions;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ProceduralWorld {
	public class World {
		Dictionary<Point, Chunk> chunks;
		Random randomizer;
		int chunkSize = 8;
		Options options;

		public World() : this(new DefaultOptions()) {
		}

		public World(Options options) {
			this.options = options;
			chunks = new Dictionary<Point, Chunk>();
			randomizer = new Random();
		}

		private void addChunkAt(Point p) {
			if (chunks.ContainsKey(p)) throw new ArgumentException("Chunk already exists at " + p);
			Chunk chunk = new Chunk(p, CHUNK_SIZE);
			chunks.Add(p, chunk);
			chunk.determine(chunks, randomizer);
		}

		private void addNeighborsIfNotExist(Point p) {
			Point p1 = new Point(p.X, p.Y + 1), p2 = new Point(p.X + 1, p.Y), p3 = new Point(p.X, p.Y - 1), p4 = new Point(p.X - 1, p.Y);
			if (!chunks.ContainsKey(p1)) addChunkAt(p1);
			if (!chunks.ContainsKey(p2)) addChunkAt(p2);
			if (!chunks.ContainsKey(p3)) addChunkAt(p3);
			if (!chunks.ContainsKey(p4)) addChunkAt(p4);
		}

		public void loadChunkInRadius(Point p, int radius) {
			loadChunk(p);
			if (radius > 0) {
				loadChunkInRadius(new Point(p.X, p.Y + 1), radius - 1);
				loadChunkInRadius(new Point(p.X + 1, p.Y), radius - 1);
				loadChunkInRadius(new Point(p.X, p.Y - 1), radius - 1);
				loadChunkInRadius(new Point(p.X - 1, p.Y), radius - 1);
			}
		}

		public void loadChunk(Point p) {
			if (p == null) throw new ArgumentNullException();
			Chunk c;
			if (!chunks.TryGetValue(p, out c)) {
				addChunkAt(p);
				chunks.TryGetValue(p, out c);
			}
			if (!c.Loaded) {
				addNeighborsIfNotExist(p);
				c.load(options.Equation, randomizer);
			}
		}

		public int CHUNK_SIZE {
			get {
				return chunkSize;
			}
			set {
				if (chunks.Keys.Count > 0) throw new MethodAccessException("Cannot set CHUNK_SIZE after world has already started generating.");
				if (value <= 0) throw new ArgumentException("CHUNK_SIZE cannot be less than or equal to 0. Attempted set was " + value);
				chunkSize = value;
			}
		}

		public Dictionary<Point, Chunk> Chunks { get { return chunks; } }

		public static Equation[] getEquations() {
			return new Equation[] { new FrequencyCurve() };
		}
	}
}
