using Godot;
using InstancingAndNamespaces.model;

namespace InstancingAndNamespaces.viewmodel;

public partial class HullViewModel : Node3D
{
    public HullModel Model { get; set; }
    [Export]
    public TurretViewModel TurretViewModel { get; set; }
    
    
    
    public override void _Ready()
    {
        Model = new HullModel();
        Model.Position = this.Position;
    }

    public override void _Process(double delta)
    {
        //Movement, etc. can be handled here for example
        base._Process(delta);
    }
}