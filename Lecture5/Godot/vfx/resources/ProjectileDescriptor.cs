using System;
using Godot;

namespace InstancingAndNamespaces.model;

[GlobalClass]
public partial class ProjectileDescriptor : Resource
{
    [Export]
    public float Damage {get; set;}
    [Export]
    public float PropagationSpeed {get; set;}
    [Export]
    public float PropagationAcceleration {get; set;}

    [Export]
    public float Lifetime {get; set;}
    
    public ProjectileDescriptor()
    {
        Damage = 10;
        PropagationSpeed = 1;
        PropagationAcceleration = 0;
    }
}


