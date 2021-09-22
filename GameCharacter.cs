using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public abstract class GameCharacter
    {
        public Random random = new Random();
        public string Name { get; set; }
        public int Health { get; set; }
        public int CurrentHealth { get; set; }
        public int Damage { get; set; }
    }
}
