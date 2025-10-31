using Godot;
using System;

namespace Lecture3.Model
{
	public partial class TestModelScript
	{
		Vector2 _velocity;
		Vector3 _position = Vector3.Zero;

		public Rect2 Bounds { get; set; } = new Rect2(-8.0f, 0.0f, 16.0f, 1.5f);
		public Vector3 Position
		{
			get
            {
				return _position;
            }
			set
            {
				_position = value;
				PositionChanged?.Invoke(this,EventArgs.Empty);
            }
		}
		public float Speed { get; set; } = 10.0f;

		// Example event
		public event EventHandler PositionChanged;

		public TestModelScript()
		{
			_velocity = Vector2.Zero;
		}
	}
}