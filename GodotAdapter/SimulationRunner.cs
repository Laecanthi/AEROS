using Godot;
using System;
using Aeros.Core.Executive;
using Aeros.Core.Utils;

public partial class SimulationRunner : Node
{
	public SimulationExecutive exec;
	private Aeros.Core.Utils.Logger _logger;

	public override void _Ready()
	{
		exec = new SimulationExecutive(100, 10);

		_logger = new Aeros.Core.Utils.Logger(exec, exec.dynamicsModel, exec.avionicsSoftwareModel);
	}

	public override void _Process(double delta)
	{
		exec.Update(delta);
		foreach(string log in _logger.PrintLog())
		{
			GD.Print(log);
		}
	}
}
