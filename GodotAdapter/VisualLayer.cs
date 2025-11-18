using Godot;
using System;

public partial class VisualLayer : Node3D
{
	public override void _Process(double delta)
	{
		var runner = (SimulationRunner) GetNode("/root/SimulationRunner");
		var exec = runner.exec;
		var dynamics = exec.dynamicsModel;

		GlobalTransform = new Transform3D(
			Basis.Identity,
			new Vector3(
				(float)dynamics.rocketPos.X,
				(float)dynamics.rocketPos.Y,
				(float)dynamics.rocketPos.Z
			)
		);
	}
}
