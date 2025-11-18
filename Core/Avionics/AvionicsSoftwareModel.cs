using System.Collections.Generic;
using Aeros.Core.Utils;
using Godot;

namespace Aeros.Core.Avionics
{
	public class AvionicsSoftwareModel : ILogSource
	{
		public double dt;
		public double t;
		public List<string> Logs { get; } = new();

		public AvionicsSoftwareModel(int avionicsHz)
		{
			dt = 1.0 / avionicsHz;
		}

		public void Update()
		{
			t += dt;
		}
	}
}
