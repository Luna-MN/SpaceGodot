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
		SunMesh.Modulate = new Color(1, 1, 0);
		for (int i = 0; i < 8; i++)
		{
			Planet planet = planetScene.Instantiate<Planet>();
			//planet.Radius = 100 + i * 50;
			planet.Radius = RNG.RandfRange(100, 1000);
			if (planet.Radius > 332.5 && planet.Radius < 697.5)
			{
				planet.mesh.Modulate = new Color(0, 1, 0);
			}

			planet.Length = 50;
			planet.offset = RNG.RandfRange(0, 2 * Mathf.Pi);
			planet.Name = "Planet" + i;
			planet.line.DefaultColor = new Color(RNG.RandfRange(0, 1), RNG.RandfRange(0, 1), RNG.RandfRange(0, 1));
			AddChild(planet);
			planets.Add(planet);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
