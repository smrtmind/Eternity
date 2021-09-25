﻿using System;
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
        public double Health { get; set; }
        public double CurrentHealth { get; set; }
        public double Damage { get; set; }
        public int Exp { get; set; }
        public int Gold { get; set; }
        public int TypeOfCharacter { get; set; }
        public int ChanceToInterruptTheEscape { get; set; }
    }
}
