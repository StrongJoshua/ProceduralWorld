using ProceduralWorld.Equations;

namespace ProceduralWorld.WorldOptions {
	public class DefaultOptions : Options {
		public DefaultOptions() {
			Equation = new FrequencyCurve();
		}
	}
}

