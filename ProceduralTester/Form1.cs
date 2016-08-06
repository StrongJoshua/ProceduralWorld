using System.Drawing;
using System.Windows.Forms;

namespace ProceduralTester {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void worldPanel_Paint(object sender, PaintEventArgs e) {
			e.Graphics.DrawLine(new Pen(Color.Blue, 1), new Point(0, 0), new Point(worldPanel.Width, worldPanel.Height));
		}
	}
}
