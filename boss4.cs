using System;

namespace EternityRPG
{
    public class boss4 : Character
    {
        public boss4()
        {
            Name = "Descendant of the fallen gods";
            Health = 8000;
            CurrentHealth = Health;
            MinDamage = 160;
            MaxDamage = 200;
            Exp = 999;
            Gold = 999;
            IsDead = false;
            ChanceToInterruptTheEscape = 100;
        }

        public override void Turn(Character player, Character boss, double bossDamage)
        {
            player.CurrentHealth -= bossDamage;

            if (player.CurrentHealth <= 0)
            {
                Print.Text($"\t{boss.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("pierces with the sword of darkness, deals ");
                Print.Text($"{bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{boss.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("pierces with the sword of darkness, deals ");
                Print.Text($"{bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.CurrentHealth} HP\n\n", ConsoleColor.DarkGreen);
            }
        }

        public override void CriticalDamage(Character player, Character enemy, double bossDamage)
        {
            player.CurrentHealth -= bossDamage *= random.Next(2, 4);

            if (player.CurrentHealth <= 0)
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("devours you with darkness from within deals ");
                Print.Text($"CRITICAL {bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("devours you with darkness from within deals ");
                Print.Text($"CRITICAL {bossDamage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.CurrentHealth} HP\n\n", ConsoleColor.DarkGreen);
            }
        }
    }
}
