namespace ProceduralWorld {
	enum Terrain { water, land }

	public class Node {
		Node[] neighbors = new Node[4];
		Terrain terrain;
		int fertility;
		internal bool Loaded { get; private set; }

		internal Node() {

		}

		internal Node TopNode {
			get {
				return neighbors[0];
			}
			set {
				neighbors[0] = value;
			}
		}

		internal Node RightNode {
			get {
				return neighbors[1];
			}
			set {
				neighbors[1] = value;
			}
		}

		internal Node BottomNode {
			get {
				return neighbors[2];
			}
			set {
				neighbors[2] = value;
			}
		}

		internal Node LeftNode {
			get {
				return neighbors[3];
			}
			set {
				neighbors[3] = value;
			}
		}
	}
}
