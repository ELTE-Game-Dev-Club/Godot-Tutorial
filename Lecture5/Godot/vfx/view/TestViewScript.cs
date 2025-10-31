using Godot;
using System;

using Lecture3.ViewModel;
using Lecture3.Model;
using System.Collections.Generic;
using InstancingAndNamespaces.viewmodel;

namespace Lecture3.View
{
	public partial class TestViewScript : Node
	{
		private TestViewModelScript _viewModel;
		private TestModelScript _model;
		private Camera3D _camera;
		private Node3D _player;

		private List<Node3D> _invaders = new List<Node3D>();

		#region  VFX

		public PackedScene HitVFX { get; set; } =
		GD.Load<PackedScene>("res://assets/vfx/AcidImpact.tscn");

		#endregion

		public int Health = 10;

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
			_model.PositionChanged += OnPositionChanged;
			_viewModel = new TestViewModelScript(_model);

			_camera = GetNode<Camera3D>("Camera3D");
			_player = GetNode<Node3D>("Player");


			PlayerControl.Instance.Ship = this;
			EmitSignal(SignalName.HealthChanged);


			for (int i = 0; i < GetChildCount(); i++)
			{
				Node child = GetChild<Node>(i);
				if (child.Name.Equals("Invader"))
				{
					_invaders.Add((Node3D)child);
				}
			}
			_model.Position = _player.Position;


		}

		private void OnPlayerHitboxBodyEntered(Node body)
		{
			var hitFX = HitVFX.Instantiate<AcidImpactVFX>();
			hitFX.Position = _player.Position;
			AddChild(hitFX);
			GD.Print("Player hit by: " + body.Name);
			this.Health--;
			EmitSignal(SignalName.HealthChanged);
		}

		[Signal]
		public delegate void HealthChangedEventHandler();
		
		public void OnPositionChanged(object sender, EventArgs e)
		{
			GD.Print("Player position changed!");
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
