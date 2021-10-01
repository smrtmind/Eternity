using System;

namespace EternityRPG
{
    public class Mage : Character
    {
        public Mage(string name, string gender)
        {
            Class = "mage";
            Health = 120;
            CurrentHealth = Health;
            MinDamage = 13;
            MaxDamage = 18;
            Name = name;
            Gender = gender;
            Gold = 0;
            Exp = 0;
        }

        public override void Turn(Character player, Character enemy, double playerDamage)
        {
            enemy.CurrentHealth -= playerDamage;

            if (enemy.CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("throws a fireball deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("died\n");

                if (enemy.GetType() == typeof(boss1) ||
                    enemy.GetType() == typeof(boss2) ||
                    enemy.GetType() == typeof(boss3) ||
                    enemy.GetType() == typeof(boss4))
                {
                    enemy.IsDead = true;
                    Print.BossVanquished();
                    Print.Text($"\n\tYou have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);
                }

                else
                    Print.Text($"\n\tVICTORY. You have earned {enemy.Gold} gold and {enemy.Exp} exp\n", ConsoleColor.DarkYellow);
            }

            else
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("throws a fireball deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("have ");
                Print.Text($"{enemy.CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }
    }
}
