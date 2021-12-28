using System;
using System.Threading;

namespace EternityRPG
{
    public class Buff : Item
    {
        public Buff(int buffType) => GetBuff(buffType);

        private void GetBuff(int buffType)
        {
            if (buffType == 1)
            {
                Cost = 110;
                MaxDurationOfEffect = 7;
                BuffPower = 30;
                Title = "Small";
            }

            else if (buffType == 2)
            {
                Cost = 235;
                MaxDurationOfEffect = 5;
                BuffPower = 70;
                Title = "Average";
            }

            else if (buffType == 3)
            {
                Cost = 390;
                MaxDurationOfEffect = 3;
                BuffPower = 200;
                Title = "Huge";
            }

            CurrentDurationOfEffect = MaxDurationOfEffect;
        }

        public override void Buy(Player player, Item[] inventory, int choice)
        {
            if (player.Gold >= Cost)
            {
                player.Gold -= Cost;
                Amount++;
                Print.Text($"\t\t\t  +1 {Title} elixir of strength\n", ConsoleColor.DarkGreen);
            }

            else Print.Text("not enough gold".PadLeft(41, ' ') + "\n", ConsoleColor.DarkRed);
            Thread.Sleep(1500);
        }

        public override void Use(Player player, Item[] inventory, int choice)
        {
            int x = choice + AmountOfBuffs() - 1;

            //turning all elixirs to false before buying new one
            for (int i = 0; i < inventory.Length; i++)
                inventory[i].BuffIsActive = false;

            //using new one
            inventory[x].BuffIsActive = true;
            inventory[x].CurrentDurationOfEffect = Game.inventory[x].MaxDurationOfEffect;
            Amount--;
        }

        public static int AmountOfBuffs()
        {
            int amountOfBuffs = default;

            for (int i = 0; i < Game.inventory.Length; i++)
                if (Game.inventory[i] is Buff)
                    amountOfBuffs++;

            return amountOfBuffs;
        }
    }
}
