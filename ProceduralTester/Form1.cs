using ProceduralWorld;
using System.Drawing;
using System.Windows.Forms;

namespace ProceduralTester {
	public partial class Form1 : Form {
		World world;

		public Form1() {
			InitializeComponent();

			world = new World();

			equationComboBox.Items.AddRange(world.getEquations());
			equationComboBox.SelectedIndex = 0;
		}

		private void worldPanel_Paint(object sender, PaintEventArgs e) {
			e.Graphics.DrawLine(new Pen(Color.Blue, 1), new Point(0, 0), new Point(worldPanel.Width, worldPanel.Height));
		}
	}
}
