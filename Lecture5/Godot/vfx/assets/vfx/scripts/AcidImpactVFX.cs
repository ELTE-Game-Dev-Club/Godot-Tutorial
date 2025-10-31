using Godot;
using System;

public partial class AcidImpactVFX : Node3D
{
    private Timer _lifetimeTimer;

    public override void _Ready()
    {
        _lifetimeTimer = GetNode<Timer>("LifetimeTimer");
        _lifetimeTimer.Timeout += OnLifetimeTimeout;
        _lifetimeTimer.Start();

        foreach (var particleSystem in GetChildren())
        {
            if (particleSystem is GpuParticles3D ps)
            {
                ps.OneShot = true;
                ps.Emitting = true;
            }
        }
    }

    private void OnLifetimeTimeout()
    {
        QueueFree();
    }

}
