using Godot;
using System;

public partial class Character : CharacterBody2D
{
	public const float Speed = 300.0f;
	public Vector2 TargetPos;
	public bool clicked = false;
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
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
		if (clicked)
		{
			Vector2 direction = (TargetPos - Position).Normalized();
			velocity = direction * Speed;
			Velocity = velocity;
			MoveAndSlide();
			if (Position.DistanceTo(TargetPos) < 10)
			{
				clicked = false;
			}

		}
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
		{

		}
		if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed)
		{
			if (Input.IsMouseButtonPressed(MouseButton.Left))
			{
				TargetPos = GetGlobalMousePosition();
				clicked = true;

			}
		}
	}
}
