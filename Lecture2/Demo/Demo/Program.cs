namespace Demo;
class DemoProgram
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Function call
        Types();
    }

    static void Types()
    {
        // Most important types 
        uint u1 = 1; // 32 bit unsigned int
        int i1 = -10; // 32 bit signed int

        Console.WriteLine($"Unsigned integer overflow: {u1 - 2}\n");
        Console.WriteLine($"Signed integer overflow: {int.MinValue + i1}\n");

        Console.WriteLine($"Conversion from unsigned to signed:{(int)u1}\n");
        Console.WriteLine($"Conversion from signed to unsiged:{(uint)i1}\n"); 

        float f1 = 5.5f; // 32 bit floating point 
        double d1 = 5.5; // 64 bit floating point
        decimal d2 = 5.5m; // 128 bit floating point 
        
        // Similarly, we lose precision by converting higher precision floating point numbers into lower ones.

        bool b1 = false;
        
        string s1 = "Video";
        // or as an alias
        String s2 = "Game";
        Console.WriteLine($"{s1 + s2}");
        NPC npc = new NPC(222);
        npc.EnemyType = EnemyType.Ranged;

        int damage = 112;
        npc.ReceiveDamage(damage);

        // damage = 112;
    }
}
