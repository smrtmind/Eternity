using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstRPG
{
    class MedicineBag : Item
    {
        public int SmallAmount { get; set; } = 0;
        public int MediumAmount { get; set; } = 0;
        public int BigAmount { get; set; } = 0;
        public int HealingPower { get; set; }

        public MedicineBag() { }

        public void AddPotion(int potionType, int amount)
        {
            switch (potionType)
            {
                case 1:
                    Name = "small";
                    HealingPower = 15;
                    SmallAmount += amount;
                    break;

                case 2:
                    Name = "medium";
                    HealingPower = 35;
                    MediumAmount += amount;
                    break;

                case 3:
                    Name = "big";
                    HealingPower = 70;
                    BigAmount += amount;
                    break;
            }
        }

        public int UsePotion(int potionType)
        {
            int returningAmount = 0;

            switch (potionType)
            {
                case 1:
                    Name = "small";
                    HealingPower = 15;
                    returningAmount = SmallAmount--;
                    break;

                case 2:
                    Name = "medium";
                    HealingPower = 35;
                    returningAmount = MediumAmount--;
                    break;

                case 3:
                    Name = "big";                 
                    HealingPower = 70;
                    returningAmount = BigAmount--;
                    break;
            }

            return returningAmount;
        }
    }
}
