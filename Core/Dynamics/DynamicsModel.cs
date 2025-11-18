using System.Collections.Generic;
using System.Data;
using System.Numerics;
using Aeros.Core.Utils;

namespace Aeros.Core.Dynamics
{
	public class DynamicsModel : ILogSource
	{
		public Vector3D rocketPos;
		public Vector3D rocketLinearVel;
		public Vector3D rocketLinearAcc;
		public Vector3D rocketThrust;
		public double mass;
		public double dt;
		public double t;
		public List<string> Logs { get; } = new();

		public DynamicsModel(int dynamicsHz)
		{
			rocketPos = new Vector3D(0,1,0);
			rocketLinearVel = new Vector3D(0,0,0);
			rocketLinearAcc = new Vector3D(0,0,0);
			mass = 0.2;
			dt = 1.0 / dynamicsHz;
		}

		public void Update()
		{
			t += dt;
			if(t<=3)
			{
				rocketThrust = new Vector3D(0,9,0);
			}
			else
			{
				rocketThrust = new Vector3D(0,0,0);
			}
			rocketLinearAcc = rocketThrust/mass + new Vector3D(0,-9.8, 0);
			rocketLinearVel += rocketLinearAcc * dt;
			rocketPos += rocketLinearVel * dt;

			Logs.Add("Vel: " + rocketLinearVel.Y);
			Logs.Add("Pos: " + rocketPos.Y);

			if(rocketPos.Y <= 1)
            {
                rocketPos.Y = 1;
            }
		}
	}
}
