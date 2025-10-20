using Godot;
using InstancingAndNamespaces.model;
using System;

public partial class InvaderViewModel : Node3D
{
    private InvaderModel Model { get; set; }

    private Timer AttackTimer { get; set; }

    public PackedScene Projectile { get; set; } =
        GD.Load<PackedScene>("res://view/projectile.tscn");

    public override void _Ready()
    {
        AttackTimer = GetNode<Timer>("AttackTimer");
        AttackTimer.Autostart = true;
        AttackTimer.Connect("timeout", new Callable(this, nameof(OnAttackTimerTimeout)));

        Model = new InvaderModel();
        Model.Position = Position;
        Model.Facing = Vector3.Forward;
        Model.Projectile = new ProjectileDescriptor()
        {
            Damage = 10,
            PropagationSpeed = 3.0f,
            PropagationAcceleration = .5f,
            Lifetime = 5.0f
        };
    }

    public void OnAttackTimerTimeout()
    {
        if (!Model.TryFireProjectile())
        {
            AttackTimer.WaitTime = 1.0f;
            GD.Print("Invader failed to shoot!");
            return;
        }
        
        AttackTimer.WaitTime = Random.Shared.NextDouble() * 3.0 + 1.0;

        var proj = Projectile.Instantiate<ProjectileViewModel>();
        this.AddChild(proj);
        proj.Model = Model.FireProjectiles();;
        proj.Model.Active = true;

        GD.Print("Invader fired a shot!");
    }
}
