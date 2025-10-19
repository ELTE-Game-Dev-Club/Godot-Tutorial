using System;
using Godot;

namespace InstancingAndNamespaces.model;

public class InvaderModel
{
    int failedShots = 0;

    public ProjectileDescriptor Projectile { get; set; }
    public Vector3 Facing { get; set; }
    
    public Vector3 Position { get; set; }

    public InvaderModel()
    {

    }

    /// <summary>
    /// Attempts to fire a projectile. If we miss too many times (3) in a row,
    /// the next shot is guaranteed to be successfully fired.
    /// </summary>
    /// <returns> 
    /// Returns true if the projectile was successfully fired and 
    /// false if the projectile was not fired.
    /// </returns>
    public bool TryFireProjectile()
    {
        Random rand = new Random();

        // If we have had 3 failed shots in a row, guarantee a hit
        if (failedShots >= 3)
        {
            failedShots = 0;
            return true;
        }

        // 55% chance to fail, but increment failed shots count
        if (rand.NextDouble() < 0.45)
        {
            failedShots++;
            return false;
        }

        // Roll for a successful shot, 
        // but don't increment failed shots count
        return true;
    }
    
    public ProjectileModel FireProjectiles()
    {
        var projectile = new ProjectileModel(this.Position,Facing,Projectile);
        
        return projectile;
    }
}