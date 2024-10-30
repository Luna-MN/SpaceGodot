using Godot;
using System;

public partial class Planet : Node2D
{
	[Export]
	public float Radius = 100;
	public int Length = 50;
	[Export]
	public float offset = 0;
	[Export]
	public Line2D line;
	[Export]
	public MeshInstance2D mesh;
	public float angle;
	public bool habitable = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		angle += (float)delta;
		GlobalPosition = ((Godot.Node2D)GetParent()).GlobalPosition + new Vector2(Mathf.Cos(angle + offset) * Radius, Mathf.Sin(angle + offset) * Radius);

	}
}
