using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; } = 0;
    }
}
