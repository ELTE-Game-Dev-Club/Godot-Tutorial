using Godot;
using System;
using InstancingAndNamespaces.model;
using InstancingAndNamespaces.viewmodel;

public partial class TurretViewModel : Node3D
{
    public TurretModel Model { get; set; }
 
    [Export]
    public HullViewModel HullViewModel { get; set; }
    
    [Export]
    public ProjectileDescriptor Descriptor { get; set; }

    public PackedScene Projectile { get; set; } =
        GD.Load<PackedScene>("res://view/projectile.tscn");
    
    public override void _Ready()
    {
        Model = new TurretModel();
        Model.Position = this.Position;
        Model.Projectile = Descriptor;
        Model.Facing = Vector3.Up;


    }

    public override void _Process(double delta)
    {

    }
    
    public override void _UnhandledInput(InputEvent @event)
    {
        // In a more complex but correct solution, we would put the event handling to the top-most ViewModel (HullViewModel in this case),
        // and propagate the input/event handling downwards

        if (@event.IsActionPressed("Fire")) 
        { 
            var proj = Projectile.Instantiate<ProjectileViewModel>();
            this.AddChild(proj);
            proj.Model = Model.FireProjectiles(); 
            proj.Model.Active = true;
        }
        
    }
}
