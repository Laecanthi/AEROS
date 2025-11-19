using System;
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
		public Quaternion rocketRotation;
		public Vector3D rocketAngularVel;
		public Vector3D rocketAngularAcc;
		public Vector3D rocketThrust;
		public Vector3D centerOfMass;
		public Vector3D centerOfPressure;
		public double mass;
		public double dt;
		public double t;
		public List<string> Logs { get; } = new();

		public DynamicsModel(int dynamicsHz)
		{
			rocketPos = new Vector3D(0,1,0);
			rocketLinearVel = new Vector3D(5,25,0);
			rocketLinearAcc = new Vector3D(0,0,0);
			centerOfMass=  new Vector3D(0,0,0);
			centerOfPressure =  new Vector3D(0,-1,0);
			rocketRotation = Quaternion.Identity;
			rocketAngularVel = new Vector3D(0,0,0);
			rocketAngularAcc = new Vector3D(0,0,0);

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
			//rocketLinearAcc = rocketThrust/mass + new Vector3D(0,-9.8, 0);
			rocketLinearAcc = new Vector3D(0,-9.8, 0);
			rocketLinearVel += rocketLinearAcc * dt;
			rocketPos += rocketLinearVel * dt;

			//Logs.Add("Vel: " + rocketLinearVel.Y);
			//Logs.Add("Pos: " + rocketPos.Y);

			if(rocketPos.Y <= 1)
			{
				rocketPos.Y = 1;
				rocketLinearVel.Y = 0;
			}

			ApplyTorque(ApplyQuaternion(centerOfMass, rocketRotation), ApplyQuaternion(centerOfPressure, rocketRotation), rocketLinearVel * 0.05 * -1);

			rocketAngularVel += rocketAngularAcc * dt;
			float angle = (float)rocketAngularVel.Length() * (float)dt;
			if(angle >= 0.00001)
			{
				var axis = Vector3.Normalize(rocketAngularVel.ToVector3());
				var deltaQ = Quaternion.CreateFromAxisAngle(axis, angle);
				rocketRotation = deltaQ * rocketRotation;
			}
		}

		public void ApplyTorque(Vector3D pivot, Vector3D application, Vector3D force)
		{
			Vector3D distanceVector = application - pivot;
			Vector3 crossProduct = Vector3.Cross(force.ToVector3(), distanceVector.ToVector3());
			Logs.Add(crossProduct.ToString());
			rocketAngularAcc += new Vector3D(crossProduct) * mass;
		}

		public Vector3D ApplyQuaternion(Vector3D vector, Quaternion quaternion)
		{
			return new Vector3D(Vector3.Transform(vector.ToVector3(), quaternion));
		}
	}
}
