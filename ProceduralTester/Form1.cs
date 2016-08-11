using ProceduralWorld;
using ProceduralWorld.Equations;
using ProceduralWorld.WorldOptions;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProceduralTester {
	public partial class Form1 : Form {
		World world;
		Point pos;
		const int loadRadius = 3;

		public Form1() {
			InitializeComponent();

			pos = new Point(0, 0);

			equationComboBox.Items.AddRange(World.getEquations());
			equationComboBox.SelectedIndex = 0;
		}

		private void worldPanel_Paint(object sender, PaintEventArgs e) {
			if (world == null) return;
			int scale = 4;
			int size = world.CHUNK_SIZE * scale;
			Dictionary<Point, Chunk> chunks = world.Chunks;
			int middleX = worldPanel.Width / 2 - size / 2;
			int startX = middleX % size;
			int sideAmtX = middleX / size;
			if (startX > 0) {
				startX -= size;
				sideAmtX++;
			}

			int middleY = worldPanel.Height / 2 - size / 2;
			int startY = middleY % size;
			int sideAmtY = middleY / size;
			if (startY > 0) {
				startY -= size;
				sideAmtY++;
			}

			Graphics g = e.Graphics;
			g.ScaleTransform(1, -1);
			g.TranslateTransform(0, -worldPanel.Height);

			for (int y = 0; y < sideAmtY * 2 + 1; y++) {
				for (int x = 0; x < sideAmtX * 2 + 1; x++) {
					Chunk c;
					if (chunks.TryGetValue(new Point(pos.X - sideAmtX + x, pos.Y - sideAmtY + y), out c))
						drawChunk(g, c, startX + x * size, startY + y * size, world.CHUNK_SIZE, scale);
				}
			}
		}

		private void drawChunk(Graphics g, Chunk c, int x, int y, int size, int scale) {
			if (!c.Loaded) {
				g.FillRectangle(new SolidBrush(Color.FromArgb(128, getBiomeColor(c.Biome))), x, y, size * scale, size * scale);
			} else {
				Node[,] nodes = c.Nodes;
				for (int i = 0; i < size; i++) {
					for (int j = 0; j < size; j++) {
						Node n = nodes[i, j];
						Color color;
						if (n.Terrain == Biome.Terrain.land) color = getFertilityColor(n.Fertility);
						else color = getBiomeColor(Biome.water);
						g.FillRectangle(new SolidBrush(color), x + i * scale, y + j * scale, scale, scale);
					}
				}
			}
		}

		private void GenerateButton_Click(object sender, System.EventArgs e) {
			world = new World(OptionsFromFields());
			world.loadChunkInRadius(pos, loadRadius);
			worldPanel.Invalidate();
		}

		private Options OptionsFromFields() {
			Options o = new DefaultOptions();
			o.Equation = (Equation)equationComboBox.SelectedItem;
			o.Equation.Modifier = (double)parameter1.Value;

			return o;
		}

		private Color getBiomeColor(Biome b) {
			if (b == Biome.forest) return Color.Green;
			else if (b == Biome.desert) return Color.Yellow;
			else if (b == Biome.water) return Color.Aqua;
			else return Color.Black;
		}

		private Color getFertilityColor(double fertility) {
			Color min = Color.Yellow;
			Color max = Color.Green;

			double r = (max.R - min.R) / Biome.MaxFertility;
			double g = (max.G - min.G) / Biome.MaxFertility;
			double b = (max.B - min.B) / Biome.MaxFertility;

			return Color.FromArgb(255, (int)(min.R + r * fertility), (int)(min.G + g * fertility), (int)(min.B + b * fertility));
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if (world == null) return;
			switch (e.KeyCode) {
				case Keys.W: pos.Y++; break;
				case Keys.D: pos.X++; break;
				case Keys.S: pos.Y--; break;
				case Keys.A: pos.X--; break;
				default: return;
			}

			world.loadChunkInRadius(pos, loadRadius);
			worldPanel.Invalidate();
		}

		private void worldPanel_Resize(object sender, System.EventArgs e) {
			worldPanel.Invalidate();
		}

		private void equationComboBox_SelectedValueChanged(object sender, System.EventArgs e) {
			parameter1.Value = (decimal)((Equation)equationComboBox.SelectedItem).Modifier;
		}
	}
}
