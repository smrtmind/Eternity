using System;

namespace EternityRPG
{
    public abstract class Enemy : Character
    {
        public int CounterToReachTheBoss { get; set; }
        public int ChanceToInterruptTheEscape { get; set; }
        public bool IsDead { get; set; }

        public override void Attack(Player player, Enemy enemy, double damage)
        {
            player.CurrentHealth -= damage;

            if (player.CurrentHealth <= 0)
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{damage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{damage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.CurrentHealth} HP\n\n", ConsoleColor.DarkGreen);
            }
        }

        public override void SpecialAttack(Player player, Enemy enemy, double damage)
        {
            player.CurrentHealth -= damage *= random.Next(2, 4);

            if (player.CurrentHealth <= 0)
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{SpecialAttackPhrase} deals ");
                Print.Text($"CRITICAL {damage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("died\n");
            }

            else
            {
                Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text($"{SpecialAttackPhrase} deals ");
                Print.Text($"CRITICAL {damage} DMG", ConsoleColor.DarkRed);
                Print.Text(", ");
                Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text("have ");
                Print.Text($"{player.CurrentHealth} HP\n\n", ConsoleColor.DarkGreen);
            }
        }
    }
}
