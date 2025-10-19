using Godot;
using System;
using InstancingAndNamespaces.model;

public partial class ProjectileViewModel : Node3D
{
    private ProjectileModel _model;

    [Export]
    public Timer Lifetime {get;set;}
    public ProjectileModel Model
    {
        get => _model;
        set
        {
           _model = value;
           this.LookAt(_model.Velocity.Normalized(), Vector3.Left);
           Model.ActiveChanged += OnActiveChanged;
           Lifetime.Start(Model.Descriptor.Lifetime);

        }
    }

    /// <summary>
    /// Event handler function. We use this to react to changes in the view-model by "subscribing" to the public event that will be invoked in the model. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnActiveChanged(object sender, EventArgs e)
    {
        if (!Model.Active)
            this.QueueFree();
        GD.Print("Projectile Destroyed");
    }

    public override void _Ready()
    {
        Lifetime.SetOneShot(true);
        Lifetime.Timeout += () =>
        {
            Model.Active = false;
        };
        
    }
    public override void _Process(double delta)
    {
        base._PhysicsProcess(delta);
        if (Model is null || !Model.Active)
            return;
        
        Model.Propagate((float)delta);
        this.SetPosition(Model.Position);
    }
    
}
