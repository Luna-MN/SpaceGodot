using Godot;
using System;

public partial class Astroid : Node2D
{
	public float Radius;
	public float offset;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = new Vector2(Radius * Mathf.Cos(offset), Radius * Mathf.Sin(offset));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
