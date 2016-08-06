using ProceduralWorld.Equations;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ProceduralWorld {
	public class World {
		Dictionary<Point, Chunk> chunks;
		Random randomizer;
		int chunkSize = 8;
		public Equation Equation { get; set; }

		public World() {
			chunks = new Dictionary<Point, Chunk>();
			randomizer = new Random();
			addChunkAt(0, 0);
			Equation = new FrequencyCurve();
		}

		private void addChunkAt(int x, int y) {
			Point p = new Point(x, y);
			if (chunks.ContainsKey(p)) throw new ArgumentException("Chunk already exists at " + p);
			Chunk chunk = new Chunk(p, CHUNK_SIZE);
			chunks.Add(p, chunk);
			chunk.determine(chunks, randomizer);
		}

		private void addNeighborsIfNotExist(Point p) {
			if (!chunks.ContainsKey(new Point(p.X, p.Y + 1))) addChunkAt(p.X, p.Y + 1);
			if (!chunks.ContainsKey(new Point(p.X + 1, p.Y))) addChunkAt(p.X + 1, p.Y);
			if (!chunks.ContainsKey(new Point(p.X, p.Y - 1))) addChunkAt(p.X, p.Y - 1);
			if (!chunks.ContainsKey(new Point(p.X - 1, p.Y))) addChunkAt(p.X - 1, p.Y);
		}

		public void loadChunkInRadius(Point p, int radius) {
			loadChunk(p);
			if(radius > 0) {
				loadChunkInRadius(new Point(p.X, p.Y + 1), radius - 1);
				loadChunkInRadius(new Point(p.X + 1, p.Y), radius - 1);
				loadChunkInRadius(new Point(p.X, p.Y - 1), radius - 1);
				loadChunkInRadius(new Point(p.X - 1, p.Y), radius - 1);
			}
		}

		public void loadChunk(Point p) {
			if (p == null) throw new ArgumentNullException();
			Chunk c;
			if (!chunks.TryGetValue(p, out c)) throw new ArgumentException("Chunk at position " + p + " has not yet been determined.");
			if (!c.Loaded) {
				addNeighborsIfNotExist(p);
				c.load(Equation);
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
	}
}
