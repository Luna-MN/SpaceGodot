using Godot;
using System;

public partial class Line2D : Godot.Line2D
{
	[Export]
	public int Length = 50;
	[Export]
	public Node2D Parent;
	public Vector2 point;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition = Vector2.Zero; // Reset the position to zero to avoid offsetting the line
		GlobalRotation = 0; // Reset the rotation to zero to avoid rotating the line
		point = ((Node2D)GetParent()).GlobalPosition;
		AddPoint(point);

		while (GetPointCount() > Length)
		{
			RemovePoint(0); // Remove the oldest point to maintain the length
		}

	}
}