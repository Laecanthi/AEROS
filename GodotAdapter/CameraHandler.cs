using Aeros.Core.Dynamics;
using Godot;
using System;
using System.Numerics;

public partial class CameraHandler : Node3D
{
	public override void _Process(double delta)
	{
		var runner = (SimulationRunner) GetNode("/root/SimulationRunner");
		var exec = runner.exec;
		var dynamics = exec.dynamicsModel;

		GlobalTransform = new Transform3D(
			Basis.Identity,
			new Godot.Vector3(
				(float)dynamics.rocketPos.X,
				(float)dynamics.rocketPos.Y + 18.5f,
				(float)dynamics.rocketPos.Z + 40f
			)
		);

		this.Rotation = new Godot.Vector3(-Mathf.Pi / 5f, 0, 0);
	}
}
