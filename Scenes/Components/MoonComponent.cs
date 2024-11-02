using Godot;
using System;

public partial class MoonComponent : Node2D
{
	[Export]
	public PackedScene moonScene;
	public RandomNumberGenerator RNG = new RandomNumberGenerator();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for (int i = 0; i < RNG.RandiRange(1, 3); i++)
		{
			Moon moon = moonScene.Instantiate<Moon>();
			moon.Radius = RNG.RandfRange(20, 50);
			moon.speed = RNG.RandfRange(0.3f, 2);
			moon.Length = 50;
			moon.offset = RNG.RandfRange(0, 2 * Mathf.Pi);
			moon.Name = "Moon" + i;
			AddChild(moon);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
