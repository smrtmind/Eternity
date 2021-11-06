using System;

namespace EternityRPG
{
    public class Enemy : Character
    {
        public int CounterToReachTheBoss { get; protected set; }
        public int ChanceToInterruptTheEscape { get; protected set; }
        public bool IsDead { get; set; }

        public override void Attack(Player player, Enemy enemy, double damage, bool crit = false)
        {
            if (!crit) player.HP -= damage;
            else player.HP -= damage *= random.Next(2, 4);

            Print.Text($"\t{enemy.Name} ", ConsoleColor.DarkMagenta);
            if (!crit)
            {
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{damage} DMG", ConsoleColor.DarkRed);
            }
            else
            {
                Print.Text($"{CriticalAttackPhrase} deals ");
                Print.Text($"CRITICAL {damage} DMG", ConsoleColor.DarkRed);
            }
            Print.Text(", ");
            Print.Text($"{player.Name} ", ConsoleColor.DarkCyan);

            if (player.HP <= 0) Print.Text("died\n");
            else
            {
                Print.Text("have ");
                Print.Text($"{player.HP} HP\n\n", ConsoleColor.DarkGreen);
            }
        }
    }
}
