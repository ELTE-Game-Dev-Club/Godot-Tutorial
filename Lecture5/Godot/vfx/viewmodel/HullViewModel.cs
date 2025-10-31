using Godot;
using InstancingAndNamespaces.model;

namespace InstancingAndNamespaces.viewmodel;

/// <summary>
/// Class representing the view model of ships, towers, turrets, etc.
/// We would use this as the top-most node of every enemy, or even the player body, and use a modular approach for
/// extending its features
/// </summary>
public partial class HullViewModel : Node3D
{
    /// <summary>
    /// (Mostly) independent of the Godot API
    /// Notice the asymmetric relationship between the model and the view-model
    /// </summary>
    public HullModel Model { get; set; }
    
    
    /// <summary>
    /// Modular implementation of a turret system, responsible for handling the enemies and players shooting actions.
    /// </summary>
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