using System.Collections.Generic;
using System.Linq;
using Godot;
using InstancingAndNamespaces.model;
using Lecture3.View;
using Lecture3.ViewModel;

namespace InstancingAndNamespaces.viewmodel;

public partial class PlayerControl : Node
{
    private static PlayerControl _instance;
    
    public static PlayerControl Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new PlayerControl();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
        
    }

    public int BombCount = 0;
    
    public int LivesCount = 0;
    
    public List<ProjectileDescriptor> Weapons = new List<ProjectileDescriptor>();
    public int ActiveWeapon = 0;


    private TestViewScript _ship;
    public TestViewScript Ship
    {
        get
        {
            return _ship;   
        }
        set
        {
            _ship = value;
            _ship.HealthChanged += (() => EmitSignal(SignalName.PlayerHealthChanged));
            
        }
        
    } 
    
    [Signal]
    public delegate void LivesChangedEventHandler();
    [Signal]
    public delegate void BombCountChangedEventHandler();
    
    [Signal]
    public delegate void PlayerHealthChangedEventHandler();
        
    private PlayerControl()
    {
        BombCount = 4;
        LivesCount = 4;
    }

    public void ReplaceActiveWeapon(ProjectileDescriptor projectile)
    {
        Weapons[0] = projectile;
    }
    
    public void SwitchToNextWeapon()
    {
        ActiveWeapon = (ActiveWeapon + 1) % Weapons.Count;    
    }

    public void SwitchToWeapon(int nth)
    {
        ActiveWeapon = nth;
    }
    
    



    
}