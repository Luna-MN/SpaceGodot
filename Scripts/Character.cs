using Godot;
using System;

public partial class Character : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{

		}
		if (Input.IsKeyPressed(Key.W))
		{
			velocity.Y = -1 * Speed;
		}
		if (Input.IsKeyPressed(Key.S))
		{
			velocity.Y = 1 * Speed;
		}
		if (Input.IsKeyPressed(Key.A))
		{
			velocity.X = -1 * Speed;
		}
		if (Input.IsKeyPressed(Key.D))
		{
			velocity.X = 1 * Speed;
		}
		if (!Input.IsKeyPressed(Key.W) && !Input.IsKeyPressed(Key.S))
		{
			velocity.Y = 0;
		}
		if (!Input.IsKeyPressed(Key.A) && !Input.IsKeyPressed(Key.D))
		{
			velocity.X = 0;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
