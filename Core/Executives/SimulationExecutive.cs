using Aeros.Core.Dynamics;
using Aeros.Core.Avionics;
using Aeros.Core.Utils;
using System.Collections.Generic;

namespace Aeros.Core.Executive
{
	public class SimulationExecutive : ILogSource
	{
		public double t;
		public int dynamicsHz;
		public int avionicsHz;
		public DynamicsModel dynamicsModel;
		public AvionicsSoftwareModel avionicsSoftwareModel;
		public List<string> Logs { get; } = new();
		public SimulationExecutive(int dHz, int aHz)
		{
			dynamicsHz = dHz;
			avionicsHz = aHz;
			dynamicsModel = new DynamicsModel(dynamicsHz);
			avionicsSoftwareModel = new AvionicsSoftwareModel(avionicsHz);
		}
		public void Update(double dt)
		{
			t += dt;
			while(dynamicsModel.t < t)
			{
				dynamicsModel.Update();
				//Log("Dynamics Updated");
			}
			while(avionicsSoftwareModel.t < t)
			{
				avionicsSoftwareModel.Update();
				//Log("Avionics Updated");
			}

			//Log($"t: {t}, Dynamics t: {dynamicsModel.t}, Avionics t: {avionicsSoftwareModel.t}");
		}

		private void Log(string log)
		{
			Logs.Add(log);
		}
	}
}
