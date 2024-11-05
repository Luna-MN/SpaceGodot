using Godot;
using System;
using System.Runtime.InteropServices;

public partial class Character : CharacterBody2D
{
	public const float baseSpeed = 300.0f;
	private const float MinZoom = 0.5f; // Minimum zoom level
	private const float MaxZoom = 10.0f; // Maximum zoom level
	private float Speed;
	public Vector2 TargetPos;
	public bool clicked = false;
	public Sun sun;
	public float angle = 0;
	[Export]
	public Camera2D camera;
	public override void _Ready()
	{
		Speed = baseSpeed;
	}
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
		if (sun != null)
		{
			angle += (float)delta;
			//Position = ((Godot.Node2D)GetParent()).GlobalPosition + new Vector2(Mathf.Cos(angle + offset) * Radius, Mathf.Sin(angle + offset) * Radius);
		}
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
			if (eventMouseButton.ButtonIndex == MouseButton.WheelUp)
			{
				ZoomCamera(1.1f); // Zoom in
			}
			else if (eventMouseButton.ButtonIndex == MouseButton.WheelDown)
			{
				ZoomCamera(0.9f); // Zoom out
			}
		}
	}

	private void ZoomCamera(float zoomFactor)
	{
		Camera2D camera = GetNode<Camera2D>("Camera2D");
		if (camera != null)
		{
			// Calculate the new zoom level
			Vector2 newZoom = camera.Zoom * zoomFactor;

			// Clamp the new zoom level to the defined limits
			newZoom.X = Mathf.Clamp(newZoom.X, MinZoom, MaxZoom);
			newZoom.Y = Mathf.Clamp(newZoom.Y, MinZoom, MaxZoom);
			// Adjust the camera's zoom
			camera.Zoom = newZoom;
			GD.Print(newZoom);
			// Adjust the player's scale inversely to the camera's zoom
			Scale = new Vector2(1 / newZoom.X, 1 / newZoom.Y);

			// Adjust the player's speed inversely to the zoom factor
			Speed = baseSpeed * Scale.X;
		}
	}
}
