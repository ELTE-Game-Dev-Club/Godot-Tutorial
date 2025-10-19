using System;
using Godot;

namespace InstancingAndNamespaces.model;

public class ProjectileModel
{
    private bool _active;
    private ProjectileDescriptor _descriptor;

    /// <summary>
    /// Whether the projectile is actively on the game map or not.
    /// </summary>
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
 

    /// <summary>
    /// Custom event for when the state of the projectile changes.
    /// Through events, we communicate changes of states to the view-model.
    /// This is important for preserving the encapsulation of the model,
    /// and for keeping it independent of the view-model. 
    /// </summary>
    public event EventHandler ActiveChanged;

    public ProjectileModel(Vector3 start,Vector3 propagationDirection,ProjectileDescriptor descriptor)
    {
        this.Descriptor = descriptor;
        Position = start;
        Velocity = propagationDirection * descriptor.PropagationSpeed;
        
    }
    
    /// <summary>
    /// Propagates the projectile forward.
    /// First we increase its velocity by the projectile types acceleration factor.
    /// Then we translate its position by the factor of velocity and propagation speed bonus. 
    /// </summary>
    /// <param name="time"></param>
    public void Propagate(float time)
    {
        Velocity += Velocity.Normalized() * Descriptor.PropagationAcceleration * time;
        Position += Velocity * Descriptor.PropagationSpeed * time;
    }
}