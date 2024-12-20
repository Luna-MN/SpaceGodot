using Godot;
using System;
using System.Collections.Generic;
public partial class AstroidBelt : Node2D
{
	public RandomNumberGenerator RNG = new RandomNumberGenerator();
	[Export]
	public float overallRaduis = 1100;
	[Export]
	public PackedScene astroidScene;
	public List<Astroid> astroids = new List<Astroid>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for (int i = 0; i < 100; i++)
		{
			Astroid astroid = astroidScene.Instantiate<Astroid>();
			astroid.Radius = RNG.RandfRange(10, 100) + overallRaduis;
			astroid.offset = RNG.RandfRange(0, 2 * Mathf.Pi);
			astroid.Name = "Astroid" + i;
			astroid.type = (Astroid.AstroidType)RNG.RandiRange(0, 2);
			astroids.Add(astroid);
			AddChild(astroid);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
