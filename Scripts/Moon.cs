using Godot;
using System;

public partial class Moon : Node2D
{
	public float Radius;
	public float speed;
	public float Length;
	public float offset;
	public float angle;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		angle += (float)delta * speed;
		GlobalPosition = ((Godot.Node2D)GetParent()).GlobalPosition + new Vector2(Mathf.Cos(angle + offset) * Radius, Mathf.Sin(angle + offset) * Radius);
	}
}
