using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternityRPG
{
    public abstract class Player : Character
    {
        public string Gender { get; set; }
        public string Class { get; set; }
        public int Lvl { get; set; } = 1;
        public double NextLvl { get; set; } = 150;

        public double GenerateDamage(Weapon weapon)
        {
            if (weapon.Weapon1Bought)
                Damage = random.Next((int)MinDamage, (int)MaxDamage) + weapon.Damage1;

            if (weapon.Weapon2Bought)
                Damage = random.Next((int)MinDamage, (int)MaxDamage) + weapon.Damage2;

            return Damage;
        }

        public void LevelUp(int exp)
        {
            if (exp >= NextLvl)
            {
                NextLvl = (int)(((NextLvl / 100) * 50) + NextLvl);

                Lvl++;
                Health = (int)(((Health / 100) * 10) + Health);
                MinDamage = (int)(((MinDamage / 100) * 10) + MinDamage);
                MaxDamage = (int)(((MaxDamage / 100) * 10) + MaxDamage);
            }
        }

        public override void Attack(Player player, Enemy enemy, double playerDamage)
        {
            enemy.CurrentHealth -= playerDamage;

            if (enemy.CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{NormalAttackPhrase} deals ");
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
                Print.Text($"{NormalAttackPhrase} deals ");
                Print.Text($"{playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("has ");
                Print.Text($"{enemy.CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }

        public override void SpecialAttack(Player player, Enemy enemy, double playerDamage)
        {
            enemy.CurrentHealth -= playerDamage *= random.Next(2, 4);

            if (enemy.CurrentHealth <= 0)
            {
                Print.Text($"\n\t{player.Name} ", ConsoleColor.DarkCyan);
                Print.Text($"{SpecialAttackPhrase} deals ");
                Print.Text($"CRITICAL {playerDamage} DMG", ConsoleColor.DarkGreen);
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
                Print.Text($"{SpecialAttackPhrase} deals ");
                Print.Text($"CRITICAL {playerDamage} DMG", ConsoleColor.DarkGreen);
                Print.Text(", ");
                Print.Text($"{enemy.Name} ", ConsoleColor.DarkMagenta);
                Print.Text("has ");
                Print.Text($"{enemy.CurrentHealth} HP\n", ConsoleColor.DarkRed);
            }
        }
    }
}
