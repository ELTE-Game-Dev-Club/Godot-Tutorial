using System;
using Godot;

namespace InstancingAndNamespaces.model;

public class ProjectileModel
{
    private bool _active;
    private ProjectileDescriptor _descriptor;

    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            ActiveChanged?.Invoke(this, EventArgs.Empty);
        }
    } 

    public bool IsEnemy {get; set;}

    
    public ProjectileDescriptor Descriptor
    {
        get => _descriptor;
        set
        {
            _descriptor = value;
        }
    }

    public Vector3 Position {get;set;}
    public Vector3 Velocity {get;set;}
 


    public event EventHandler ActiveChanged;

    public ProjectileModel(Vector3 start,Vector3 propagationDirection,ProjectileDescriptor descriptor)
    {
        this.Descriptor = descriptor;
        Position = start;
        Velocity = propagationDirection * descriptor.PropagationSpeed;
        
    }
    
    public void Propagate(float time)
    {
        Velocity += Velocity.Normalized() * Descriptor.PropagationAcceleration * time;
        Position += Velocity * Descriptor.PropagationSpeed * time;
    }
}