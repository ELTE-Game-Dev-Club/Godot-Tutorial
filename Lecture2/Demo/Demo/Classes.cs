using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    /// <summary>
    /// This is a summary detailing the usage and purpose of the NPC class. 
    /// Similar summaries can be made for properties, methods, fields, etc.
    /// Very helpful for documenting your code to you and your peers!
    /// </summary>
    public abstract class NPC
    {
        /*-----------------------------
        public = Visible from code outside the object/class.
        protected = Only visible from inherited classes, and from code written inside the class.
        private = Only visible from code written inside the class. For example, from methods, constructors, etc.
         -----------------------------*/

        // Fields
        private float _speed;
        protected bool _active = false;
        public int _goldLoot = 4;

        // Properties - It is recommended to use these, as they encapsulate how you can access and modify attributes concisely
        public int Id { get; set; }

        protected int Health { get; set; } = 20;

        public float Speed { get => _speed; }

        public EnemyType EnemyType { get; set; }

        // Constructor
        public NPC(int id) {
            _speed = 12.5f;
            Id = id;
        }

        public void ReceiveDamage(int damage) {
            damage = 33;
            Health += damage;
        }

        public void InventoryAddTo(ref int[] inventory, int at)
        {
            // Arguments with the 'ref' keyword may have a value assigned to them before termination of the function.
            inventory[at] = 4;
        }

        public virtual void GetEnemyType(out EnemyType type)
        {
            // Arguments with the 'out' keyword must have a value assigned to them before termination of the function.
            type = EnemyType.Unknown;
        }
        
    }

    public enum EnemyType
    {   
        Unknown = 0,// Recieves value 0
        Ranged  = 1,
        Melee   = 3
    }

    public interface IDamageDealer
    {
        public int Damage { get; set; }
        public void DealDamage(NPC other)
        {
            other.ReceiveDamage(Damage);
        }

        public abstract void ApplyEffect(NPC other);

        // Difference between virtual and abstract methods
        // Virtual
        // Abstract
    }

    // Difference between interface and abstract class
    // Inteface: ~ contracts, nouns, keywords
    // Abs. class: ~ base class, template

    public class Enemy : NPC, IDamageDealer{

        public EnemyType Type { get; init; }
        public int Damage { get; set; }

        // private bool _active;

        // Constructors with parameter
        public Enemy(int id) : base(id) // Initializing the base class
        {
            _active = true;
            _goldLoot = 0;
            Type = EnemyType.Ranged;
        }
        public Enemy(int id, EnemyType type) : base(id) 
        {
            Type = type;
        } 

        // Default constructor
        public Enemy() : base(0) {}


        // Virtual function from IDamageDealer interface overwritten
        public override void GetEnemyType(out EnemyType type)
        {
            type = this.Type;
        }

        // Abstract function from IDamageDealer interface realized
        public void ApplyEffect(NPC other)
        {
            other._goldLoot = 0;
        }
    }
}
