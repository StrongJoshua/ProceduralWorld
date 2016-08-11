namespace ProceduralWorld.Equations {
	public abstract class Equation {
		public double Modifier { get; set; }
		public abstract double evaluate(double x);
	}
}
