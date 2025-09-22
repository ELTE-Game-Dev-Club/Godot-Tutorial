using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    //Singleton - Design pattern. Useful for allowing one and only one instance of a class to exist globally
    //Read more at: https://refactoring.guru/design-patterns/singleton
    public class GlobalNPCManager
    {
        public List<NPC> npcs;

        // Single existing instance
        private static GlobalNPCManager instance;

        // Private constructor, so that we restrict the creation of objects of this class to the outside
        private GlobalNPCManager() { 
            npcs = new List<NPC>();
        }

        // Static method for accessing the global instance and creating it if it's not yet initialized
        public static GlobalNPCManager GetInstance() {
            if (instance is null)
            {
                instance = new GlobalNPCManager();
            }

            return instance;
        }

        public void AddNpc(NPC npc)
        {
            npcs.Add(npc);
        }

        public void RemoveNpc(NPC npc) { 
            npcs.Remove(npc);
        }
        
    }
}
