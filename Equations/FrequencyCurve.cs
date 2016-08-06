using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralWorld.Equations {
	class FrequencyCurve : Equation {
		public double Modifier { get; set; }
		public override double evaluate(double x) {
			return Math.Sqrt(Math.Pow(x, -1.0 * Math.Pow(Modifier * x, 2.0)) / 2.0);
		}
	}
}
