using Godot;
using Lecture3.Model;

namespace Lecture3.ViewModel
{
	public partial class TestViewModelScript
	{
		private TestModelScript _model;

		public Rect2 Bounds
		{
			get => _model.Bounds;
			set => _model.Bounds = value;
		}
		public Vector3 Position 
		{
			get => _model.Position;
			set => _model.Position = value;
		}
		public float Speed
		{
			get => _model.Speed;
			set => _model.Speed = value;
		}

		public TestViewModelScript(TestModelScript model)
		{
			_model = model;
		}
	}
}
