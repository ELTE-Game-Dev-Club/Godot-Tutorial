using System.Collections.Generic;
using Godot;

namespace InstancingAndNamespaces.model;

/// <summary>
/// Class realizing projectile firing behaviours
/// </summary>
public class TurretModel
{
    public ProjectileDescriptor Projectile { get; set; }
    public Vector3 Facing { get; set; }
    
    public Vector3 Position { get; set; }
    

    /// <summary>
    /// Responsible for creating the projectiles using the current state of the turret.
    /// </summary>
    /// <returns></returns>
    public ProjectileModel FireProjectiles()
    {
        var projectile = new ProjectileModel(this.Position,Facing,Projectile);
        
        return projectile;
    }
    

}