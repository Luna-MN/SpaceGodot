using Godot;
using System;
using System.Collections.Generic;

public partial class PlanetComponent : Node2D
{
	public RandomNumberGenerator RNG = new RandomNumberGenerator();
	[Export]
	public PackedScene planetScene;
	public bool radiusPicked = false;
	public List<Planet> planets = new List<Planet>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for (int i = 0; i < RNG.RandiRange(3, 8); i++)
		{
			Planet planet = planetScene.Instantiate<Planet>();
			//planet.Radius = 100 + i * 50;
			planet.Radius = RNG.RandfRange(100, 1000);
			planet.speed = RNG.RandfRange(0.3f, 2);
			if (planet.Radius > 332.5 && planet.Radius < 697.5)
			{
				planet.mesh.Modulate = new Color(0.6f, 1, 0.6f);
				planet.habitable = true;
			}
			else
			{
				planet.mesh.Modulate = new Color(1f, 0.6f, 0.6f);
			}
			planet.Length = 50;
			planet.offset = RNG.RandfRange(0, 2 * Mathf.Pi);
			planet.Name = "Planet" + i;
			planet.line.DefaultColor = new Color(RNG.RandfRange(0, 1), RNG.RandfRange(0, 1), RNG.RandfRange(0, 1));

			planets.Add(planet);
			bool radiusPicked = false;

			while (!radiusPicked)
			{
				planet.Radius = RNG.RandfRange(100, 1000);
				bool validRadius = true;

				foreach (Planet p in planets)
				{
					if ((planet.Radius < p.Radius && planet.Radius > p.Radius - 80) || (planet.Radius > p.Radius && planet.Radius < p.Radius + 80))
					{
						validRadius = false;
						break;
					}
				}

				if (planet.Radius > 400 && planet.Radius < 550)
				{
					validRadius = false;
				}

				if (validRadius)
				{
					radiusPicked = true;
				}
			}
			AddChild(planet);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
