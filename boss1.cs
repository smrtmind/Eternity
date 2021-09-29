using System;

namespace EternityRPG
{
    public class boss1 : Character
    {
        public boss1()
        {
            Name = "Evil forest spirit";
            Health = 2000;
            CurrentHealth = Health;
            MinDamage = 70;
            MaxDamage = 100;
            Exp = 300;
            Gold = 450;
            IsDead = false;
            CounterToReachTheBoss = 2;
            ChanceToInterruptTheEscape = 100;
        }

        public override void Turn(Character player, Character[] boss, double bossDamage, int index)
        {
            if (player.CurrentHealth <= 0)
            {
                Print.Text($"\t{boss[index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("strikes with a branch deals ");
                Print.Text($"{bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{boss[index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("strikes with a branch deals ");
                Print.Text($"{bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.CurrentHealth} HP\n\n", ConsoleColor.DarkGreen);
            }               
        }
    }
}
