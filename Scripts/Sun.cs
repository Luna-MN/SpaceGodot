using Godot;
using System;
using System.Collections.Generic;

public partial class Sun : Node2D
{
	[Export]
	public PackedScene planetScene;
	[Export]
	public MeshInstance2D SunMesh;
	public List<Planet> planets = new List<Planet>();
	public RandomNumberGenerator RNG = new RandomNumberGenerator();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SunMesh.Modulate = new Color(1, 1, 0.4f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
