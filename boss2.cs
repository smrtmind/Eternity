using System;

namespace EternityRPG
{
    public class boss2 : Character
    {
        public boss2()
        {
            Name = "Spiteful golem";
            Health = 3000;
            CurrentHealth = Health;
            MinDamage = 100;
            MaxDamage = 130;
            Exp = 500;
            Gold = 700;
            IsDead = false;
            CounterToReachTheBoss = 2;
            ChanceToInterruptTheEscape = 100;
        }

        public override void Turn(Character player, Character[] boss, double bossDamage)
        {
            if (player.CurrentHealth <= 0)
            {
                Print.Text($"\t{boss[Program.index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("throws a huge stone, deals ");
                Print.Text($"{bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{boss[Program.index].Name} ", ConsoleColor.DarkMagenta);
                Print.Text("throws a huge stone, deals ");
                Print.Text($"{bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.CurrentHealth} HP\n\n", ConsoleColor.DarkGreen);
            }
        }
    }
}
