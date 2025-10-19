using Godot;
using System;

using Lecture3.ViewModel;
using Lecture3.Model;

namespace Lecture3.View
{
	public partial class TestViewScript : Node
	{
		private TestViewModelScript _viewModel;
		private TestModelScript _model;
		private Camera3D _camera;
		private Node3D _player;
		[Export]
		public float Speed
		{
			get => _viewModel.Speed;
			set => _viewModel.Speed = value;
		}

		public Rect2 Playerbounds
		{
			get => _viewModel.Bounds;
			set => _viewModel.Bounds = value;
		}

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			base._Ready();

			_model = new TestModelScript();
			_viewModel = new TestViewModelScript(_model);

			_camera = GetNode<Camera3D>("Camera3D");
			_player = GetNode<Node3D>("Player");

			_model.Position = _player.Position;
		}

		public override void _PhysicsProcess(double delta)
		{
			// We create a local variable to store the input direction.
			var direction = Vector3.Zero;

			// We check for each move input and update the direction accordingly.
			if (Input.IsActionPressed("ui_up"))
			{
				direction.Y += Input.GetActionStrength("ui_up");
			}
			if (Input.IsActionPressed("ui_down"))
			{
				direction.Y -= Input.GetActionStrength("ui_down");
			}
			if (Input.IsActionPressed("ui_left"))
			{
				direction.X -= Input.GetActionStrength("ui_left");
			}
			if (Input.IsActionPressed("ui_right"))
			{
				direction.X += Input.GetActionStrength("ui_right");
			}

			if (direction != Vector3.Zero)
			{
				// Lerp movement for smoother motion
				direction = direction.Normalized();			

				_player.Position += direction * Speed * (float)delta;

				// Clamp the player position to the defined bounds
				_player.Position = new Vector3(
					Mathf.Clamp(_player.Position.X, Playerbounds.Position.X, Playerbounds.End.X),
					Mathf.Clamp(_player.Position.Y, Playerbounds.Position.Y, Playerbounds.End.Y),
					_player.Position.Z
				);

				_model.Position = _player.Position;
			}
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{

		}
	}
}

