using Aeros.Core.Dynamics;
using Godot;
using System;
using System.Numerics;

public partial class VisualLayer : Node3D
{
	public override void _Process(double delta)
	{
		var runner = (SimulationRunner) GetNode("/root/SimulationRunner");
		var exec = runner.exec;
		var dynamics = exec.dynamicsModel;

		System.Numerics.Quaternion qSys = dynamics.rocketRotation;

		Godot.Quaternion qGodot = new Godot.Quaternion(
	qSys.X,
	qSys.Y,
	qSys.Z,
	qSys.W
);

		GlobalTransform = new Transform3D(
			Basis.Identity,
			new Godot.Vector3(
				(float)dynamics.rocketPos.X,
				(float)dynamics.rocketPos.Y,
				(float)dynamics.rocketPos.Z
			)
		);

		Quaternion = qGodot;
	}
}
