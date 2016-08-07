﻿using System;

namespace ProceduralWorld.Equations {
	class FrequencyCurve : Equation {
		public double Modifier { get; set; }
		public override double evaluate(double x) {
			return Math.Sqrt(Math.Pow(x, -1.0 * Math.Pow(Modifier * x, 2.0)) / 2.0);
		}

		public override string ToString() {
			return "Frequency Curve";
		}
	}
}
