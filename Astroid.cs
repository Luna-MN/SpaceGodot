using Godot;
using System;

public partial class Astroid : Node2D
{
	public enum AstroidType
	{
		Normal,
		Ice,
		Metal,
	}
	[Export]
	public MeshInstance2D mesh;
	public AstroidType type;
	public float Radius;
	public float offset;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = new Vector2(Radius * Mathf.Cos(offset), Radius * Mathf.Sin(offset));
		if (type == AstroidType.Normal)
		{
			mesh.Modulate = new Color(0.6f, 0.6f, 0.6f);
		}
		else if (type == AstroidType.Ice)
		{
			mesh.Modulate = new Color(0.6f, 0.6f, 1);
		}
		else if (type == AstroidType.Metal)
		{
			mesh.Modulate = new Color(1, 0.6f, 0.6f);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
